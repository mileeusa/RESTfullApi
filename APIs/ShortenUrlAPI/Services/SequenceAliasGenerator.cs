using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShortenUrlAPI.Services
{
    public sealed class SequenceAliasGeneratorOptions
    {
        /// <summary>
        /// Database sequence name to use. For Postgres this is typically "schema.sequence_name" or "sequence_name".
        /// For SQL Server use the sequence identifier as created.
        /// Default: "shorturl_alias_seq"
        /// </summary>
        public string SequenceName { get; set; } = "shorturl_alias_seq";
    }

    public class SequenceAliasGenerator : IAliasGenerator
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<SequenceAliasGenerator> _logger;
        private readonly string _sequenceName;

        public SequenceAliasGenerator(DbContext dbContext,
                                      IOptions<SequenceAliasGeneratorOptions> options,
                                      ILogger<SequenceAliasGenerator> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sequenceName = options?.Value?.SequenceName ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<string> GenerateAliasAsync(CancellationToken cancellationToken = default)
        {
            var provider = _dbContext.Database.ProviderName?.ToLowerInvariant() ?? string.Empty;
            string sql;

            if (provider.Contains("npgsql"))
            {
                // PostgreSQL
                sql = $"SELECT nextval('{_sequenceName}')";
            }
            else if (provider.Contains("sqlserver"))
            {
                // SQL Server
                sql = $"SELECT NEXT VALUE FOR {_sequenceName}";
            }
            else
            {
                sql = $"SELECT NEXT VALUE FOR {_sequenceName}";
            }

            DbConnection connection = _dbContext.Database.GetDbConnection();
            try
            {
                await _dbContext.Database.OpenConnectionAsync(cancellationToken).ConfigureAwait(false);

                using var command = connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                if (command is DbCommand dbCommand)
                {
                    var result = await dbCommand.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    if (result == null)
                    {
                        throw new InvalidOperationException("Sequence returned null value.");
                    }

                    ulong id;
                    switch (result)
                    {
                        case long l: id = (ulong)l; break;
                        case int i: id = (ulong)i; break;
                        case decimal d: id = (ulong)d; break;
                        case byte b: id = b; break;
                        case ushort us: id = us; break;
                        case uint ui: id = ui; break;
                        case ulong ul: id = ul; break;
                        case string s when ulong.TryParse(s, out var parsed): id = parsed; break;
                        default:
                            id = Convert.ToUInt64(result);
                            break;
                    }

                    return Base62.Encode(id);
                }
                else
                {
                    throw new InvalidOperationException("Unable to create DB command for sequence retrieval.");
                }
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await _dbContext.Database.CloseConnectionAsync().ConfigureAwait(false);
                }
            }
        }
    }
}

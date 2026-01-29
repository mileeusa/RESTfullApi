using System.Threading;
using System.Threading.Tasks;

namespace ShortenUrlAPI.Services
{
    public interface IAliasGenerator
    {
        /// <summary>
        /// Generates the next alias using a sequence + Base62 encoding.
        /// </summary>
        Task<string> GenerateAliasAsync(CancellationToken cancellationToken = default);
    }
}

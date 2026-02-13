using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShortenUrlAPI.Services;

namespace ShortenUrlAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAliasGenerator(this IServiceCollection services, string sequenceName = "shorturl_alias_seq")
        {
            services.Configure<SequenceAliasGeneratorOptions>(opts => opts.SequenceName = sequenceName);

            // Register the SequenceAliasGenerator using the application's DbContext (any registered DbContext will be resolved)
            services.AddScoped<IAliasGenerator, SequenceAliasGenerator>();

            return services;
        }
    }
}

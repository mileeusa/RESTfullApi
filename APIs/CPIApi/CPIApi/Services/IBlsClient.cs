using CpiApi.Models;

namespace CpiApi.Services
{
    public interface IBlsClient
    {
        /// <summary>
        /// Returns CPI value (integer) and notes for given seriesId, year, month.
        /// Caches result for 1 day to reduce calls to BLS public API.
        /// </summary>
        Task<CpiResponse?> GetCpiForMonthAsync(int year, int month, string? seriesId);
    }
}

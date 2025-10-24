using CpiApi.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Memory;
using System.IO;
using System.Text.Json;

namespace CpiApi.Services
{
    public class BlsClient : IBlsClient
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlsClient> _logger;

        public BlsClient(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache, IConfiguration configuration, ILogger<BlsClient> logger)
        {
            _httpFactory = httpClientFactory;
            _cache = memoryCache;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// the API to retrieve the CPI value from the CPI service of Bureau of Labor Statistics  
        /// </summary>
        /// <param name="seriesId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns>the CPI response</returns>
        /// 
        /// Time Complexity: O(N), Space Complexity O(1)
        /// 
        public async Task<CpiResponse?> GetCpiForMonthAsync(int year, int month, string? seriesId)
        {
            var baseUrl = _configuration["Bls:BaseUrl"] ?? "https://api.bls.gov/publicAPI/v2/timeseries/data/";
            var sId = string.IsNullOrWhiteSpace(seriesId) ? (_configuration["Bls:DefaultSeriesId"] ?? "LAUCN040010000000005") : seriesId;
            var cacheKey = $"cpi:{sId}:{year}-{month:D2}";

            if (_cache.TryGetValue<CpiResponse>(cacheKey, out var cachedEntry))
            {
                return cachedEntry;
            }

            string url = $"{baseUrl}/{sId}";

            var client = _httpFactory.CreateClient("bls");

            try
            {
                var resp = await client.GetAsync(url);
                if (!resp.IsSuccessStatusCode)
                {
                    _logger.LogWarning("BLS API returned non-success: {Status}", resp.StatusCode);
                    return null;
                }

                using var stream = await resp.Content.ReadAsStreamAsync();
                using var doc = await JsonDocument.ParseAsync(stream);

                // The BLS public API's response shape may be: { "status": "...", "Results": { "series": [ { "seriesID": "...", "data": [ ... ] } ] } }
                if (!doc.RootElement.TryGetProperty("Results", out var resultsEl)) 
                    return null;

                if (!resultsEl.TryGetProperty("series", out var seriesEl)) 
                    return null;

                if (seriesEl.ValueKind != JsonValueKind.Array || seriesEl.GetArrayLength() == 0) 
                    return null;

                var series0 = seriesEl[0];
                if (!series0.TryGetProperty("data", out var dataEl)) 
                    return null;

                foreach (var item in dataEl.EnumerateArray())
                {
                    // here is the sample data from the response:
                    // { "year":"2025","period":"M08","periodName":"August","latest":"true","value":"17649","footnotes":[{ "code":"P","text":"Preliminary."}]}

                    if (!item.TryGetProperty("year", out var yearEl) || !item.TryGetProperty("period", out var periodEl)) 
                        continue;

                    if (!int.TryParse(yearEl.GetString(), out var itemYear)) 
                        continue;

                    // period: "M05" for May; extract month
                    var period = periodEl.GetString() ?? "";

                    if (!period.StartsWith("M")) 
                        continue;

                    if (!int.TryParse(period.Substring(1), out var itemMonth)) 
                        continue;

                    if (itemYear == year && itemMonth == month)
                    {
                        // value
                        string? valueStr = null;
                        if (item.TryGetProperty("value", out var valueEl))
                            valueStr = valueEl.GetString();

                        int intValue = 0;
                        if (!string.IsNullOrEmpty(valueStr))
                        {
                            // parse decimal and round to nearest integer
                            if (decimal.TryParse(valueStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var dec))
                                intValue = (int)Math.Round(dec, MidpointRounding.AwayFromZero);
                        }

                        // collect notes
                        string notes = "";
                        if (item.TryGetProperty("footnotes", out var footnotes) && footnotes.ValueKind == JsonValueKind.Array)
                        {
                            var sb = new System.Text.StringBuilder();
                            foreach (var f in footnotes.EnumerateArray())
                            {
                                if (f.TryGetProperty("text", out var t) && !string.IsNullOrWhiteSpace(t.GetString()))
                                {
                                    if (sb.Length > 0) sb.Append(" | ");
                                    sb.Append(t.GetString());
                                }
                            }
                            notes = sb.ToString();
                        }

                        var response = new CpiResponse
                        {
                            Value = intValue,
                            Notes = notes
                        };

                        // cache for 1 day
                        _cache.Set(cacheKey, response, TimeSpan.FromDays(1));
                        return response;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception calling BLS API");
                return null;
            }
        }
    }
}

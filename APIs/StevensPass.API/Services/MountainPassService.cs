using Microsoft.Extensions.Caching.Memory;
using StevensPass.API.Models;

namespace StevensPass.API.Services
{
    public interface IMountainPassService
    {
        Task<MountainPassStatus?> GetMountainPassStatusAsync();
    }

    public class MountainPassService : IMountainPassService
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "mountain_status";

        public MountainPassService(IMemoryCache cache)
        {
            _cache = cache;
        }

        // Here is an example of the mountain pass status JSON structure we might get from an external API:
        //  {
        //    "DateUpdated":"\/Date(1765784463873-0800)\/",
        //    "ElevationInFeet":4061,
        //    "Latitude":47.745,
        //    "Longitude":-121.093333,
        //    "MountainPassId":10,
        //    "MountainPassName":"Stevens Pass US 2",
        //    "RestrictionOne":
        //    {
        //      "RestrictionText":"Pass Closed",
        //      "TravelDirection":"Eastbound"
        //    },
        //    "RestrictionTwo":
        //    {
        //      "RestrictionText":"Pass Closed",
        //      "TravelDirection":"Westbound"
        //    },
        //    "RoadCondition":"US 2 is closed from milepost 50 near Skykomish to milepost 99 at Leavenworth, ...",
        //    "TemperatureInFahrenheit":36,
        //    "TravelAdvisoryActive":true,
        //    "WeatherCondition":"Clear skies"
        //  }
        //
        public async Task<MountainPassStatus?> GetMountainPassStatusAsync()
        {
            return await _cache.GetOrCreateAsync(CacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);

                // TODO: replace with real data
                await Task.Delay(50);

                return new MountainPassStatus
                {
                    IsEastboundOpen = true,
                    ElevationInFeet = 5,                   
                    Summary = "Good snow conditions.",
                    LastUpdated = DateTime.UtcNow
                };
            });
        }
    }
}

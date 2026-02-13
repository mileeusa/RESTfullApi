using Microsoft.Extensions.Caching.Memory;
using StevensPass.API.Models;

namespace StevensPass.API.Services
{
    public interface IRoadService
    {
        Task<RoadStatus?> GetRoadStatusAsync();
    }

    public class RoadService : IRoadService
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "road_status";

        public RoadService(IMemoryCache cache) 
        {
            _cache = cache;
        }

        public async Task<RoadStatus?> GetRoadStatusAsync()
        {
            return await _cache.GetOrCreateAsync(CacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);

                // TODO: Replace with real WSDOT API call
                // http://wsdot.wa.gov/Traffic/api/MountainPassConditions/MountainPassConditionsREST.svc/GetMountainPassConditionAsJon?AccessCode={ACCESSCODE}&PassConditionID={PASSCONDITIONID}
                //
                // Stevnes Pass:
                //   access code: 5ea02a84-c8a3-404e-9cca-438e15a39029
                //   pass condition Id: 10
                //
                await Task.Delay(50);

                return new RoadStatus
                {
                    PassName = "Stevens Pass US-2",
                    Status = "Open",
                    Conditions = "Chains required",
                    LastUpdated = DateTime.UtcNow
                };
            });
        }
    }
}

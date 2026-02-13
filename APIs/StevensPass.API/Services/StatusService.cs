using StevensPass.API.Models;

namespace StevensPass.API.Services
{
    public interface IStatusService
    {
        Task<CombinedStatus> GetCombinedStatusAsync();
    }
    public class StatusService : IStatusService
    {
        private readonly IRoadService _roadService;
        private readonly IMountainPassService _mountainService;
        public StatusService(IRoadService roadService, IMountainPassService mountainService)
        {
            _roadService = roadService;
            _mountainService = mountainService;
        }

        public async Task<CombinedStatus> GetCombinedStatusAsync()
        {
           var roadStatusTask = _roadService.GetRoadStatusAsync();
            var mountainStatusTask = _mountainService.GetMountainPassStatusAsync();

            await Task.WhenAll(roadStatusTask, mountainStatusTask);

            return new CombinedStatus
            {
                Road = roadStatusTask.Result,
                Mountain = mountainStatusTask.Result,
                GeneratedAt = DateTime.UtcNow
            };
        }
    }
}

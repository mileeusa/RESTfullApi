

using StevensPass.API.Services;

namespace StevensPass.API.BackgroundJobs
{
    public class DataRefreshWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DataRefreshWorker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateScope();

                var _road = scope.ServiceProvider.GetRequiredService<IRoadService>();
                var _mountain = scope.ServiceProvider.GetRequiredService<IMountainPassService>();

                await _road.GetRoadStatusAsync();
                await _mountain.GetMountainPassStatusAsync();

                Task.Delay(TimeSpan.FromMinutes(15), stoppingToken).Wait(stoppingToken);
            }
        }
    }
}

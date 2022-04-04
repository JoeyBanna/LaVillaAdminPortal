namespace BlazorApp.Helper
{
    public class MyBackGroundService : BackgroundService, IDisposable
    {
        private readonly ILogger<ServiceCollection> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MyBackGroundService(ILogger<ServiceCollection> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("My Background Service is starting.");

        }
    }
}

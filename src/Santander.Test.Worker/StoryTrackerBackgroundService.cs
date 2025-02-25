
using Santander.Test.Application.Services.Abstractions;

namespace Santander.Test.Worker;

public class StoryTrackerBackgroundService(
    IServiceProvider serviceProvider,
    ILogger<StoryTrackerBackgroundService> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ILogger<StoryTrackerBackgroundService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var serviceScope = _serviceProvider.CreateScope();
                var service = serviceScope.ServiceProvider.GetRequiredService<IUpdateStoryService>();
                await service.UpdateBestStoriesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hacker News polling failed with the error: {Message}", ex.Message);
            }

            await Task.Delay(30 * 1000, stoppingToken);
        }
    }
}

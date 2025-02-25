
using Santander.Test.Application.Services.Abstractions;

namespace Santander.Test.Worker;

public class StoryTrackerBackgroundService(IServiceProvider serviceProvider) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var service = serviceScope.ServiceProvider.GetRequiredService<IUpdateStoryService>();
            await service.UpdateBestStoriesAsync(stoppingToken);
            await Task.Delay(10000, stoppingToken);
        }
    }
}

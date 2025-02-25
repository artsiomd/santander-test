namespace Santander.Test.Application.Services.Abstractions;

public interface IUpdateStoryService
{
    Task UpdateBestStoriesAsync(CancellationToken cancellationToken = default);
}
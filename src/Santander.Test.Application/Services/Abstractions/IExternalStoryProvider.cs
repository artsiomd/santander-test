namespace Santander.Test.Application.Services.Abstractions;

public interface IExternalStoryProvider
{
    Task<List<long>> GetBestStoryIdsAsync();

    Task<StoryDto?> GetStoryAsync(long id);
}

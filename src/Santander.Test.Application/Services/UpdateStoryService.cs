using Santander.Test.Application.Services.Abstractions;
using Santander.Test.Domain;

namespace Santander.Test.Application.Services;

internal class UpdateStoryService(
    IStoryRepository storyRepository,
    IExternalStoryProvider externalStoryProvider)
    : IUpdateStoryService
{
    private readonly IStoryRepository _storyRepository = storyRepository;
    private readonly IExternalStoryProvider _externalStoryProvider = externalStoryProvider;

    public async Task UpdateBestStoriesAsync(CancellationToken cancellationToken = default)
    {
        var storyIds = await _externalStoryProvider.GetBestStoryIdsAsync();
        var stories = await Task.WhenAll(storyIds.Select(_externalStoryProvider.GetStoryAsync));

        var storiesToSave = stories
            .Where(x => x != null)
            .Select(x => x!)
            .OrderByDescending(x => x.Score)
            .ToList();

        await _storyRepository.SaveBestStoriesAsync(storiesToSave);
    }
}

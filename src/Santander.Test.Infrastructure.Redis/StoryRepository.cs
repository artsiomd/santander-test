using Microsoft.Extensions.Caching.Distributed;
using Santander.Test.Domain;
using System.Text.Json;

namespace Santander.Test.Infrastructure.Redis;

public class StoryRepository(IDistributedCache cache) : IStoryRepository
{
    private const string BestStoriesKey = "best-stories";
    private readonly IDistributedCache _cache = cache;

    public async Task<List<Story>> GetBestStoriesAsync()
    {
        var storiesSerialized = await _cache.GetStringAsync(BestStoriesKey);
        if (string.IsNullOrEmpty(storiesSerialized))
        {
            return [];
        }


        return JsonSerializer.Deserialize<List<Story>>(
            storiesSerialized,
            SourceGenerationJsonContext.Default.ListStory) ?? [];
    }

    public async Task SaveBestStoriesAsync(List<Story> stories)
    {
        var storiesSerialized = JsonSerializer.Serialize(
            stories,
            SourceGenerationJsonContext.Default.ListStory);
        await _cache.SetStringAsync(BestStoriesKey, storiesSerialized);
    }
}

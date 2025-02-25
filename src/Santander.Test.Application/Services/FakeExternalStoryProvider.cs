using Santander.Test.Application.Services.Abstractions;

namespace Santander.Test.Application.Services;

internal class FakeExternalStoryProvider : IExternalStoryProvider
{
    private readonly Dictionary<long, StoryDto> _storage = new()
    {
        {
            1,
            new StoryDto("Valve releases Team Fortress 2 code",
                new Uri("https://github.com/ValveSoftware/source-sdk-2013/commit/0759e2e8e179d5352d81d0d4aaded72c1704b7a9"),
                "davikr",
                DateTimeOffset.FromUnixTimeSeconds(1739908637),
                1607,
                387)
        },
        {
            2,
            new StoryDto("Valve releases Team Fortress 1 code",
                new Uri("https://github.com/ValveSoftware/source-sdk-2013/commit/0759e2e8e179d5352d81d0d4aaded72c1704b7a9"),
                "davikr",
                DateTimeOffset.FromUnixTimeSeconds(1739908637),
                1704,
                260)
        },
        {
            3,
            new StoryDto (
                "Valve releases Team Fortress 3 code",
                new Uri("https://github.com/ValveSoftware/source-sdk-2013/commit/0759e2e8e179d5352d81d0d4aaded72c1704b7a9"),
                "davikr",
                DateTimeOffset.FromUnixTimeSeconds(1739908637),
                1509,
                45)
        }
    };
    public Task<List<long>> GetBestStoryIdsAsync()
    {
        return Task.FromResult(new List<long> { 1, 2, 3 });
    }

    public Task<StoryDto?> GetStoryAsync(long id)
    {
        _storage.TryGetValue(id, out var result);
        return Task.FromResult(result);
    }
}

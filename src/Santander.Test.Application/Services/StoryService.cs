using Santander.Test.Application.Services.Abstractions;
using Santander.Test.Domain;

namespace Santander.Test.Application.Services;

internal class StoryService(IStoryRepository storyRepository) : IStoryService
{
    private readonly IStoryRepository _storyRepository = storyRepository;

    public async Task<List<StoryDto>> GetBestStoriesAsync(int? count)
    {
        if (count.HasValue && count < 1)
        {
            throw new ArgumentException("Count must be positive");
        }

        var savedStories = await _storyRepository.GetBestStoriesAsync();
        return savedStories
            .Take(count ?? savedStories.Count)
            .Select(x => new StoryDto(x))
            .ToList();
    }
}

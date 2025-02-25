namespace Santander.Test.Application.Services.Abstractions;

public interface IStoryService
{
    Task<List<StoryDto>> GetBestStoriesAsync(int? count);
}
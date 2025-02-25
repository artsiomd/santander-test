namespace Santander.Test.Domain;

public interface IStoryRepository
{
    Task<List<Story>> GetBestStoriesAsync();

    Task SaveBestStoriesAsync(List<Story> stories);
}

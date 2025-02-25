using Santander.Test.Domain;

namespace Santander.Test.Application.Services.Abstractions;

public interface IExternalStoryProvider
{
    Task<List<long>> GetBestStoryIdsAsync();

    Task<Story?> GetStoryAsync(long id);
}

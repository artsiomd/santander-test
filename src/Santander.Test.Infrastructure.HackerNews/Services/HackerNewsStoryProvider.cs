using Santander.Test.Application.Services.Abstractions;
using Santander.Test.Domain;
using System.Net.Http.Json;

namespace Santander.Test.Infrastructure.HackerNews.Services;

internal class HackerNewsStoryProvider(HttpClient httpClient) : IExternalStoryProvider
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<long>> GetBestStoryIdsAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<long>>("/v0/beststories.json");

        return result ?? [];
    }

    public async Task<Story?> GetStoryAsync(long id)
    {
        if(id < 1)
        {
            return null;
        }

        var result = await _httpClient.GetFromJsonAsync<HackerNewsItem>($"/v0/item/{id}.json");

        return result?.Map();
    }
}

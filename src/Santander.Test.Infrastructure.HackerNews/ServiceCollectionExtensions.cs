using Microsoft.Extensions.DependencyInjection;
using Santander.Test.Application.Services.Abstractions;
using Santander.Test.Infrastructure.HackerNews.Services;

namespace Santander.Test.Infrastructure.HackerNews;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHackerNewsProvider(this IServiceCollection services)
    {
        services.AddHttpClient<IExternalStoryProvider, HackerNewsStoryProvider>(client =>
        {
            client.BaseAddress = new Uri("https://hacker-news.firebaseio.com");
        });

        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using Santander.Test.Application.Services;
using Santander.Test.Application.Services.Abstractions;

namespace Santander.Test.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStoryApiApplication(this IServiceCollection services)
    {
        services.AddScoped<IStoryService, StoryService>();

        return services;
    }

    public static IServiceCollection AddStoryWorkerApplication(this IServiceCollection services)
    {
        services.AddScoped<IUpdateStoryService, UpdateStoryService>();

        return services;
    }

    public static IServiceCollection AddFakeHackerNewsProvider(this IServiceCollection services)
    {
        services.AddScoped<IExternalStoryProvider, FakeExternalStoryProvider>();

        return services;
    }
}

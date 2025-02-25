using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Santander.Test.Domain;

namespace Santander.Test.Infrastructure.Redis;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStoryPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("RedisConnection");
            options.InstanceName = "SampleInstance";
        });
        services.AddSingleton<IStoryRepository, StoryRepository>();

        return services;
    }
}

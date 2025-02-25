using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Santander.Test.Application.Services.Abstractions;
using Santander.Test.Infrastructure.HackerNews.Services;

namespace Santander.Test.Infrastructure.HackerNews;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHackerNewsProvider(this IServiceCollection services)
    {
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        var circuitBreakerPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(10, TimeSpan.FromSeconds(30));
        var bulkheadPolicy = Policy
            .BulkheadAsync<HttpResponseMessage>(10, int.MaxValue);
        var resilientPolicy = Policy.WrapAsync(
            retryPolicy,
            circuitBreakerPolicy,
            bulkheadPolicy);

        services
            .AddHttpClient<IExternalStoryProvider, HackerNewsStoryProvider>(client =>
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com");
            })
            .AddPolicyHandler(resilientPolicy);

        return services;
    }
}

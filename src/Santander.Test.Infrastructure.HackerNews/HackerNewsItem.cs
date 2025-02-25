using Santander.Test.Domain;

namespace Santander.Test.Infrastructure.HackerNews;

public record HackerNewsItem(
    long Id,
    string Title,
    string Url,
    string By,
    long Time,
    int Score,
    int Descendants)
{
    public Story Map()
    {
        return new(
            Title,
            string.IsNullOrEmpty(Url) ? null : new Uri(Url),
            By,
            DateTimeOffset.FromUnixTimeMilliseconds(Time),
            Score,
            Descendants);
    }
}

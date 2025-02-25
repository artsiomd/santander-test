using Santander.Test.Domain;

namespace Santander.Test.Application;

public record StoryDto(
    string Title,
    string? Uri,
    string PostedBy,
    DateTimeOffset Time,
    int Score,
    int CommentCount)
{

    public StoryDto(Story story)
        : this(story.Title, story.Uri?.AbsoluteUri, story.PostedBy, story.Time, story.Score, story.CommentCount)
    { }
}

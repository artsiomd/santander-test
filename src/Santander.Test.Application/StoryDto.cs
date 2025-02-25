using Santander.Test.Domain;

namespace Santander.Test.Application;

public record StoryDto(
    string Title,
    Uri Uri,
    string PostedBy,
    DateTimeOffset Time,
    int Score,
    int CommentCount)
{

    public StoryDto(Story story)
        :this(story.Title, new Uri(story.Uri), story.PostedBy, story.Time, story.Score, story.CommentCount)
    { }

    public Story Map()
    {
        return new(Title, Uri.AbsoluteUri, PostedBy, Time, Score, CommentCount);
    }
}

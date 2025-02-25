namespace Santander.Test.Domain
{
    public class Story(
        string title,
        Uri? uri,
        string postedBy,
        DateTimeOffset time,
        int score,
        int commentCount)
    {
        public string Title { get; private set; } = title;

        public Uri? Uri { get; private set; } = uri;

        public string PostedBy { get; private set; } = postedBy;

        public DateTimeOffset Time { get; private set; } = time;

        public int Score { get; private set; } = score;

        public int CommentCount { get; private set; } = commentCount;
    }
}

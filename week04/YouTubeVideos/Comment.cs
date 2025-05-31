using System;

namespace YouTubeVideos
{
    // The Comment class is responsible for tracking
    // the name of the commenter and the text of the comment.
    public class Comment
    {
        // Name of the person who made the comment
        public string AuthorName { get; set; }

        // Text of the comment
        public string Text { get; set; }

        // Constructor to set both properties
        public Comment(string authorName, string text)
        {
            AuthorName = authorName;
            Text = text;
        }
    }
}

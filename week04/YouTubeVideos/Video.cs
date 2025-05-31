using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // The Video class is responsible for storing
    // the title, author, length (in seconds), and
    // a list of Comment objects. It exposes a method
    // to retrieve the number of comments (abstraction).
    public class Video
    {
        // Title of the video
        public string Title { get; set; }

        // Author (uploader) of the video
        public string Author { get; set; }

        // Length of the video in seconds
        public int LengthInSeconds { get; set; }

        // Internal list to store comments
        private List<Comment> _comments;

        // Public read-only access to the comments (if needed)
        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

        // Constructor initializes properties and instantiates the list
        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        // Method to add a comment to this video
        public void AddComment(Comment comment)
        {
            if (comment != null)
            {
                _comments.Add(comment);
            }
        }

        // Method that returns the number of comments (abstraction)
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }
    }
}

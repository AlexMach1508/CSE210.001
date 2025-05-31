using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold multiple Video objects
            List<Video> videos = new List<Video>();

            // -----------------------------
            // Video 1 with 3–4 comments
            // -----------------------------
            Video video1 = new Video(
                title: "C# Abstraction Tutorial",
                author: "Tech Academy",
                lengthInSeconds: 600
            );
            video1.AddComment(new Comment("Alice", "Great explanation on abstraction!"));
            video1.AddComment(new Comment("Bob", "Can you do a follow-up on encapsulation?"));
            video1.AddComment(new Comment("Charlie", "Thanks for the code samples!"));

            videos.Add(video1);

            // -----------------------------
            // Video 2 with 4 comments
            // -----------------------------
            Video video2 = new Video(
                title: "Understanding Interfaces in C#",
                author: "CodeMaster",
                lengthInSeconds: 420
            );
            video2.AddComment(new Comment("David", "Interfaces always confused me; this helped."));
            video2.AddComment(new Comment("Eve", "Can you compare interfaces vs abstract classes?"));
            video2.AddComment(new Comment("Frank", "Nice delivery and pace."));
            video2.AddComment(new Comment("Grace", "Please cover dependency injection next!"));

            videos.Add(video2);

            // -----------------------------
            // Video 3 with 3 comments
            // -----------------------------
            Video video3 = new Video(
                title: "LINQ Queries for Beginners",
                author: "Dev World",
                lengthInSeconds: 730
            );
            video3.AddComment(new Comment("Heidi", "LINQ makes data querying so simple."));
            video3.AddComment(new Comment("Ivan", "Any tips for optimizing LINQ performance?"));
            video3.AddComment(new Comment("Judy", "Excellent examples!"));

            videos.Add(video3);

            // -----------------------------
            // Video 4 with 4 comments
            // -----------------------------
            Video video4 = new Video(
                title: "Async and Await in C# Explained",
                author: "AsyncPro",
                lengthInSeconds: 810
            );
            video4.AddComment(new Comment("Kyle", "Async/Await was confusing until now."));
            video4.AddComment(new Comment("Laura", "Could you create a playlist with more async patterns?"));
            video4.AddComment(new Comment("Mike", "Thanks for clarifying ConfigureAwait."));
            video4.AddComment(new Comment("Nina", "Helpful real-world examples."));

            videos.Add(video4);

            // --------------------------------------------------
            // Iterate through each Video and display its details
            // --------------------------------------------------
            foreach (Video vid in videos)
            {
                Console.WriteLine($"Title: {vid.Title}");
                Console.WriteLine($"Author: {vid.Author}");
                
                // Convert length in seconds to mm:ss format for readability
                int minutes = vid.LengthInSeconds / 60;
                int seconds = vid.LengthInSeconds % 60;
                Console.WriteLine($"Length: {minutes} minute(s) {seconds} second(s)");

                // Display number of comments using the method from Video
                Console.WriteLine($"Number of Comments: {vid.GetNumberOfComments()}");

                // List out all comments for the video
                Console.WriteLine("Comments:");
                foreach (Comment c in vid.Comments)
                {
                    Console.WriteLine($" - {c.AuthorName}: {c.Text}");
                }

                // Separator between videos
                Console.WriteLine(new string('-', 40));
            }

            // Keep the console window open until a key is pressed
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

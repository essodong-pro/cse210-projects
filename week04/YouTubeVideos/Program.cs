using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        foreach (Comment c in comments)
        {
            Console.WriteLine($" - {c.CommenterName}: {c.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Sew a Dress", "Nia", 300);
        video1.AddComment(new Comment("Ama", "Great tutorial!"));
        video1.AddComment(new Comment("Kwame", "Very helpful, thanks."));
        video1.AddComment(new Comment("Efua", "Can you show trousers next?"));

        Video video2 = new Video("Business Tips for Beginners", "Nia", 450);
        video2.AddComment(new Comment("Kojo", "This was inspiring."));
        video2.AddComment(new Comment("Akua", "Loved the examples."));
        video2.AddComment(new Comment("Yaw", "Please make more videos!"));

        Video video3 = new Video("Marketing Basics", "Nia", 600);
        video3.AddComment(new Comment("Kofi", "Clear and easy to follow."));
        video3.AddComment(new Comment("Abena", "This helped my startup."));
        video3.AddComment(new Comment("Kwesi", "Could you cover social media?"));

        Video video4 = new Video("Fashion Show Highlights", "Nia", 720);
        video4.AddComment(new Comment("Esi", "Amazing designs!"));
        video4.AddComment(new Comment("Kojo", "Loved the creativity."));
        video4.AddComment(new Comment("Ama", "Please post more events."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display info for each video
        foreach (Video v in videos)
        {
            v.DisplayVideoInfo();
        }
    }
}

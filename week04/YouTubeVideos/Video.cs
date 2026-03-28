using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    // Read-only properties
    public string Title => _title;
    public string Author => _author;
    public int Length => _length;

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        foreach (Comment c in _comments)
        {
            Console.WriteLine($" - {c.CommenterName}: {c.Text}");
        }
        Console.WriteLine();
    }
}

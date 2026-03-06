using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _tags; // Creativity: added tagging system

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"Tags: {_tags}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }
}

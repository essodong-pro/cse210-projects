using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
        LogActivity();
    }

    public void ShowSpinner(int seconds)
    {
        string[] sequence = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(sequence[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % sequence.Length;
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }

    private void LogActivity()
    {
        string logEntry = $"{DateTime.Now}: Completed {_name} for {_duration} seconds\n";
        System.IO.File.AppendAllText("log.txt", logEntry);
    }
}

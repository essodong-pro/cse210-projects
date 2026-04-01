using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        Random rand = new Random();

        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You will have a few seconds to think...");
        ShowSpinner(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }
}

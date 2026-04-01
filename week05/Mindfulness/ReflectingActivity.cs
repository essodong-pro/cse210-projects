using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        Random rand = new Random();

        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }

        DisplayEndingMessage();
    }
}

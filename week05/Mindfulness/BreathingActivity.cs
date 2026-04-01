using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            elapsed += 3;

            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
            elapsed += 3;
        }

        DisplayEndingMessage();
    }
}

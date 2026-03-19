// Exceeding requirements: I added support for multiple scriptures chosen randomly.
// This helps practice memorization with variety.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Library of scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, " +
                "that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths.")
        };

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}

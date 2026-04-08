using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int points = _goals[goalIndex].RecordEvent();
            _score += points;
            Console.WriteLine($"You earned {points} points!");
            CheckLevelUp();
            CheckBadges();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\n--- Goals ---");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} - {_goals[i].Description}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour score: {_score}");
        Console.WriteLine($"Your level: {_score / 1000}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string data = parts[1];

            switch (type)
            {
                case "SimpleGoal": _goals.Add(SimpleGoal.FromString(data)); break;
                case "EternalGoal": _goals.Add(EternalGoal.FromString(data)); break;
                case "ChecklistGoal": _goals.Add(ChecklistGoal.FromString(data)); break;
            }
        }
        Console.WriteLine("Goals loaded.");
    }

    private void CheckLevelUp()
    {
        int level = _score / 1000;
        if (_score % 1000 == 0 && _score != 0)
        {
            Console.WriteLine($"🎉 Level Up! You are now level {level}!");
        }
    }

    private void CheckBadges()
    {
        foreach (Goal goal in _goals)
        {
            if (goal is EternalGoal eternal && eternal.TimesRecorded >= 5)
            {
                Console.WriteLine("🏅 Badge débloqué : Scripture Scholar !");
            }
        }

    }
}
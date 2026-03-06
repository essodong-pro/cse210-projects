using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}|{entry._tags}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry entry = new Entry
            {
                _date = parts[0],
                _prompt = parts[1],
                _response = parts[2],
                _tags = parts[3]
            };
            _entries.Add(entry);
        }
    }

    // Creativity: filter entries by tag
    public void FilterByTag(string tag)
    {
        Console.WriteLine($"Entries with tag: {tag}");
        foreach (Entry entry in _entries)
        {
            if (entry._tags.Contains(tag, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
            }
        }
    }
}

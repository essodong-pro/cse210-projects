using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (Word word in _words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        for (int i = 0; i < 3; i++) // hide 3 words each time
        {
            int index = _rand.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}

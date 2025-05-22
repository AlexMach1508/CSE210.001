using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            _entries.Add(Entry.FromFileString(line));
        }
        Console.WriteLine("Journal loaded.");
    }

    public void FilterEntries(string search)
    {
        var filtered = _entries.Where(entry =>
            entry.Date.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            entry.Prompt.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            entry.Response.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("No matching entries found.");
        }
        else
        {
            Console.WriteLine($"\nFiltered entries for \"{search}\":");
            foreach (Entry entry in filtered)
            {
                entry.Display();
            }
        }
    }
}

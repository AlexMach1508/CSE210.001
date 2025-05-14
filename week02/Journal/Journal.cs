using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
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

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            entries.Add(Entry.FromFileString(line));
        }
        Console.WriteLine("Journal loaded.");
    }

    public void FilterEntries(string search)
    {
        var filtered = entries.Where(e =>
            e.Date.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            e.Prompt.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            e.Response.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("No matching entries found.");
        }
        else
        {
            Console.WriteLine($"\nFiltered entries for \"{search}\":");
            foreach (var entry in filtered)
            {
                entry.Display();
            }
        }
    }
}

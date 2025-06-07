using System;
using System.Collections.Generic;
using System.IO;

static class ActivityLogger
{
    private const string LogFileName = "activity_log.txt";
    private static List<string> _entries = new List<string>();

    // Load existing log entries at startup
    public static void LoadLog()
    {
        if (File.Exists(LogFileName))
        {
            _entries = new List<string>(File.ReadAllLines(LogFileName));
        }
    }

    // Record completion of an activity
    public static void LogCompletion(string activityName)
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Completed {activityName}";
        _entries.Add(entry);
    }

    // Save log entries to disk on exit
    public static void SaveLog()
    {
        File.WriteAllLines(LogFileName, _entries);
    }
}
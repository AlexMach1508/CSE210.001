using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            var goal = _goals[index];

            if (goal is ChecklistGoal cg)
            {
                cg.RecordEvent();
                _score += cg.Points;
                if (cg.IsComplete()) _score += cg.Bonus;
            }
            else if (goal is ProgressGoal pg)
            {
                pg.RecordEvent();
                _score += pg.ProgressEarned();
            }
            else if (goal is NegativeGoal ng)
            {
                ng.RecordEvent();
                _score -= ng.Points;
            }
            else
            {
                goal.RecordEvent();
                _score += goal.Points;
            }

            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split("|");

            switch (type)
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                    if (bool.Parse(data[3])) sg.RecordEvent(); // Set complete
                    _goals.Add(sg);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]));
                    for (int j = 0; j < int.Parse(data[5]); j++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;
                case "ProgressGoal":
                    var pg = new ProgressGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                    pg.RecordProgress(int.Parse(data[4]));
                    _goals.Add(pg);
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                    break;
            }
        }
    }
}

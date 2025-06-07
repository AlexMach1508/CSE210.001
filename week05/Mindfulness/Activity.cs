using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _durationInSeconds;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _durationInSeconds = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    protected void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {_name} Activity for {_durationInSeconds} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b ");
        }
        Console.WriteLine();
    }

    public abstract void Run();
}
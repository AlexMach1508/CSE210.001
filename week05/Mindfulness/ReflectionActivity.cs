using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        // Add more prompts...
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // Add more questions...
    };

    public ReflectionActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public override void Run()
    {
        Start();
        var rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < _durationInSeconds)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
            elapsed += 5;
        }
        End();
    }
}

using System;
using System.Collections.Generic;

class GratitudeActivity : Activity
{
    private Queue<string> _prompts;

    public GratitudeActivity() : base(
        "Gratitude",
        "This activity will help you cultivate gratitude by listing things you are thankful for.")
    {
        // Initialize prompt queue to cycle without repeats
        var prompts = new List<string>
        {
            "List a person in your life you are grateful for.",
            "List an experience you are thankful you had.",
            "List a personal strength you appreciate in yourself.",
            "List something in nature you are grateful for.",
            "List an opportunity you were thankful to receive."
        };
        var rand = new Random();
        // Shuffle and enqueue
        for (int i = prompts.Count - 1; i >= 0; i--)
        {
            int j = rand.Next(i + 1);
            var temp = prompts[i]; prompts[i] = prompts[j]; prompts[j] = temp;
        }
        _prompts = new Queue<string>(prompts);
    }

    public override void Run()
    {
        Start();
        if (_prompts.Count == 0) return;
        // Dequeue and display one prompt
        Console.WriteLine(_prompts.Dequeue());
        ShowSpinner(3);

        Console.WriteLine("You may begin listing. Press Enter after each item:");
        Console.WriteLine($"You have {_durationInSeconds} seconds. Go!");

        int count = 0;
        var endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        while (DateTime.Now < endTime)
        {
            if (!string.IsNullOrWhiteSpace(Console.ReadLine())) count++;
        }

        Console.WriteLine($"You listed {count} items of gratitude!");
        End();
    }
}

using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
    };

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        Start();
        var rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin listing items. Press Enter after each item:");
        Console.WriteLine($"You have {_durationInSeconds} seconds. Go!");

        int count = 0;
        var endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        while (DateTime.Now < endTime)
        {
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                count++;
        }

        Console.WriteLine($"You listed {count} items!");
        End();
    }
}
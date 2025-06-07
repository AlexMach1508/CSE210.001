using System;
class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();
        int elapsed = 0;
        while (elapsed < _durationInSeconds)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            elapsed += 4;

            Console.Write("Breathe out...");
            ShowCountdown(6);
            elapsed += 6;
        }
        End();
    }
}
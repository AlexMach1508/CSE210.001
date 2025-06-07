using System;

// Exceeded Requirements:
// - Added a new "GratitudeActivity", allowing users to list things they are grateful for, extending beyond simple listing.
// - Implemented persistent session tracking: each completed activity is recorded in "activity_log.txt"; logs are loaded at startup and saved on exit.
// - Ensured unique prompts/questions: Reflection and Listing (and Gratitude) cycle through their full set before repeating.
// - Enhanced BreathingActivity animation: spinner accelerates during the first half of each breath and decelerates in the second half for a more natural pacing.
// - Modular design supports easy addition of future activities and centralized logging support.

class Program
{
    static void Main(string[] args)
    {
        // Load or initialize activity usage log
        ActivityLogger.LoadLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(),
                "5" => null,
                _ => null
            };

            if (activity == null)
                break;

            activity.Run();
            ActivityLogger.LogCompletion(activity.GetType().Name);

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        // Save usage log before exit
        ActivityLogger.SaveLog();
    }
}


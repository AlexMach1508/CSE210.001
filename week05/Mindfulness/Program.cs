using System;


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


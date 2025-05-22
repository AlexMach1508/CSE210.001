using System;
using System.Collections.Generic;

// EXCEEDS REQUIREMENTS: Program works with a library of scriptures and selects one randomly at runtime.

class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."),
            new Scripture(new Reference("Psalm", 23, 1),
                "The Lord is my shepherd; I shall not want.")
        };

        var random = new Random();
        int index = random.Next(scriptures.Count);
        var selectedScripture = scriptures[index];

        var hider = new Hider();

        while (true)
        {
            Console.Clear();
            selectedScripture.Display();

            if (selectedScripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Press any key to exit.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            hider.HideRandomWords(selectedScripture, 3);
        }
    }
}

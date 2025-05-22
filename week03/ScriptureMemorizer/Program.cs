using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        var text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        var scripture = new Scripture(reference, text);
        var hider = new Hider();

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Press any key to exit.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            hider.HideRandomWords(scripture, 3); // Use Hider to hide words
        }
    }
}

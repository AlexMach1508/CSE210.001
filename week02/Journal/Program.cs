// ENHANCEMENT: This version exceeds the core requirements by:
// - Displaying full date and time in journal entries.
// - Allowing the user to filter journal entries by date or keyword.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string userChoice = "";
        while (userChoice != "6")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Filter journal entries");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    journal.AddEntry(new Entry(dateTime, prompt, response));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.Write("Enter date (YYYY-MM-DD) or keyword to filter: ");
                    string filter = Console.ReadLine();
                    journal.FilterEntries(filter);
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1-6.");
                    break;
            }
        }
    }
}

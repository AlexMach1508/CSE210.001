// EXTRA CREDIT FEATURES:
// - Added ProgressGoal: Tracks partial progress toward large goals (e.g. running 50 miles).
// - Added NegativeGoal: Records bad habits and subtracts points as penalties.
// These additions demonstrate polymorphism, new gamification strategies, and deeper goal tracking.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    Console.Write("Filename to save: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;
                case "4":
                    Console.Write("Filename to load: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;
                case "5":
                    manager.ShowGoals();
                    Console.Write("Enter goal number to record event: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case "6":
                    manager.ShowScore();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target times to complete: ");
                int checklistTarget = int.Parse(Console.ReadLine());

                Console.Write("Bonus points on completion: ");
                int bonus = int.Parse(Console.ReadLine());

                manager.AddGoal(new ChecklistGoal(name, description, points, checklistTarget, bonus));
                break;

            case "4":
                Console.Write("Target amount: ");
                int progressTarget = int.Parse(Console.ReadLine());

                Console.Write("Points per unit of progress: ");
                int perUnit = int.Parse(Console.ReadLine());

                manager.AddGoal(new ProgressGoal(name, description, perUnit, progressTarget));
                break;
            case "5":
                Console.Write("Penalty points to subtract: ");
                int penalty = int.Parse(Console.ReadLine());
                manager.AddGoal(new NegativeGoal(name, description, penalty));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}

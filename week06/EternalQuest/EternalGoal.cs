public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"You recorded progress on '{_name}' and earned {_points} points!");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

    public override string GetStringRepresentation() =>
        $"EternalGoal:{_name}|{_description}|{_points}";
}

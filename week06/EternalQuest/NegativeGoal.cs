public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, penaltyPoints)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Penalty of {_points} points recorded.");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() =>
        $"[ ] {_name} ({_description}) -- Lose {_points} points if recorded";

    public override string GetStringRepresentation() =>
        $"NegativeGoal:{_name}|{_description}|{_points}";
}

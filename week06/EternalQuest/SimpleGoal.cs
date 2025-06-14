public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() =>
        $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
}

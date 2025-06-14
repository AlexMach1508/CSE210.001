public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonus;
    public int Bonus => _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _completedCount = 0;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _completedCount++;
    }

    public override bool IsComplete() => _completedCount >= _targetCount;

    public override string GetDetailsString() =>
        $"[{(_completedCount >= _targetCount ? "X" : " ")}] {_name} ({_description}) -- Completed {_completedCount}/{_targetCount}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_completedCount}";
}

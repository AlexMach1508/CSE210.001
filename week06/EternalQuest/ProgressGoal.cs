public class ProgressGoal : Goal
{
    private int _target;
    private int _currentProgress;
    private int _pointsPerUnit;

    public ProgressGoal(string name, string description, int pointsPerUnit, int target)
        : base(name, description, pointsPerUnit)
    {
        _pointsPerUnit = pointsPerUnit;
        _target = target;
        _currentProgress = 0;
    }

    public void RecordProgress(int value)
    {
        _currentProgress += value;
    }

    public override void RecordEvent()
    {
        Console.Write("How much progress did you make (e.g., miles run)? ");
        int input = int.Parse(Console.ReadLine());
        _currentProgress += input;
        _points = input * _pointsPerUnit;
    }

    public override bool IsComplete() => _currentProgress >= _target;

    public override string GetDetailsString() =>
        $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- Progress: {_currentProgress}/{_target}";

    public override string GetStringRepresentation() =>
        $"ProgressGoal:{_name}|{_description}|{_pointsPerUnit}|{_target}|{_currentProgress}";

    public int ProgressEarned() => _points;
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            return _points + _bonusPoints;
        }
        return _points;
    }

    public override string GetStatus() =>
        _isComplete ? "[X]" : $"[ ] Completed {_currentCount}/{_targetCount}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_currentCount},{_bonusPoints},{_isComplete}";

    public static ChecklistGoal FromString(string data)
    {
        string[] parts = data.Split(",");
        ChecklistGoal goal = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]),
                                               int.Parse(parts[3]), int.Parse(parts[5]));
        goal._currentCount = int.Parse(parts[4]);
        goal._isComplete = bool.Parse(parts[6]);
        return goal;
    }
}

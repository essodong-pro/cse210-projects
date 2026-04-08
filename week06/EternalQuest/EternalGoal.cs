class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return _points;
    }

    public override string GetStatus() => $"[∞] Recorded {_timesRecorded} times";

    public override string GetStringRepresentation() =>
        $"EternalGoal:{_name},{_description},{_points},{_timesRecorded}";

    public static EternalGoal FromString(string data)
    {
        string[] parts = data.Split(",");
        EternalGoal goal = new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
        goal._timesRecorded = int.Parse(parts[3]);
        return goal;
    }

    public int TimesRecorded => _timesRecorded;
}

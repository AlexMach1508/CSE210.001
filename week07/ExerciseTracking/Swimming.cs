public class Swimming : Activity
{
    private readonly int _laps;
    private const double MetersPerLap  = 50;
    private const double MilesPerMeter = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps, double weightKg)
        : base(date, minutes, weightKg)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double meters = _laps * MetersPerLap;
        return meters * MilesPerMeter;           // convert to miles
    }

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace()  => Minutes / GetDistance();
    protected override double GetMet() => 6.0;         // moderate laps
}

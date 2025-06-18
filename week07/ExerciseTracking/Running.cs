public class Running : Activity
{
    private readonly double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles, double weightKg)
        : base(date, minutes, weightKg)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance() => _distanceMiles;
    public override double GetSpeed()    => (_distanceMiles / Minutes) * 60;
    public override double GetPace()     => Minutes / _distanceMiles;
    protected override double GetMet()   => 9.8;          // ~6 mph running
}

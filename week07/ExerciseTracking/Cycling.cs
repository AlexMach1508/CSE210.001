public class Cycling : Activity
{
    private readonly double _speedMph;

    public Cycling(DateTime date, int minutes, double speedMph, double weightKg)
        : base(date, minutes, weightKg)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance() => _speedMph * Minutes / 60;
    public override double GetSpeed()    => _speedMph;
    public override double GetPace()     => 60 / _speedMph;
    protected override double GetMet()   => 7.0;          // moderate stationary cycling
}

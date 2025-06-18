using System;

public abstract class Activity
{
    private readonly DateTime _date;
    private readonly int      _minutes;
    private readonly double   _weightKg;        // user weight for calories

    protected Activity(DateTime date, int minutes, double weightKg)
    {
        _date     = date;
        _minutes  = minutes;
        _weightKg = weightKg;
    }

    public DateTime Date           => _date;
    public int      DurationMinutes => _minutes;
    protected int   Minutes        => _minutes;
    protected double WeightKg      => _weightKg;

    // ---------- calculations required of every activity ----------
    public abstract double GetDistance();   // miles (internal base unit)
    public abstract double GetSpeed();      // mph
    public abstract double GetPace();       // minutes per mile
    protected abstract double GetMet();     // MET value for calorie calc

    // ---------- new universal calorie burn ----------
    public double GetCalories() => GetMet() * _weightKg * _minutes / 60.0;

    // ---------- common summary with unit conversion ----------
    public virtual string GetSummary()
    {
        double dist   = Units.Current == UnitSystem.Imperial
                      ? GetDistance()
                      : Units.MilesToKm(GetDistance());

        double speed  = Units.Current == UnitSystem.Imperial
                      ? GetSpeed()
                      : Units.MilesToKm(GetSpeed());

        double pace   = Units.Current == UnitSystem.Imperial
                      ? GetPace()
                      : Units.PaceMileToKm(GetPace());

        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min)- "
             + $"Distance {dist:0.00} {Units.DistanceUnit}, "
             + $"Speed {speed:0.0} {Units.SpeedUnit}, "
             + $"Pace {pace:0.00} {Units.PaceUnit}, "
             + $"Calories {GetCalories():0} kcal";
    }
}

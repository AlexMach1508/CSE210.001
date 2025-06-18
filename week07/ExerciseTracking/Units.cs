public enum UnitSystem { Imperial, Metric }

public static class Units
{
    public static UnitSystem Current = UnitSystem.Imperial;           // toggle here

    private const double KmPerMile = 1.60934;
    private const double MilesPerKm = 1 / KmPerMile;

    public static string DistanceUnit => Current == UnitSystem.Imperial ? "miles" : "km";
    public static string SpeedUnit    => Current == UnitSystem.Imperial ? "mph"   : "kph";
    public static string PaceUnit     => Current == UnitSystem.Imperial ? "min per mile"
                                                                        : "min per km";

    public static double MilesToKm(double miles) => miles * KmPerMile;
    public static double KmToMiles(double km)    => km   * MilesPerKm;

    public static double PaceMileToKm(double pace) => pace / KmPerMile;   // min/mi → min/km
}

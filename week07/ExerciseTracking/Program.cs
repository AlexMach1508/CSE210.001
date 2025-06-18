/*
 * --------------------------------------------------------------------------
 * Enhancements (beyond core assignment):
 * 1. **Unit-System Toggle** – Summaries can be shown in miles/imperial or km/metric
 *    by changing `Units.Current` (see below).
 * 2. **Calorie Tracking** – Each activity estimates calories burned using MET
 *    values and user weight (kcal displayed in summaries and totals).
 * 3. **Daily Totals** – After listing all activities, the program aggregates
 *    total time, distance and calories for a quick daily overview.
 * 4. **Reusable Conversion Utilities** – Added Units.cs to centralise
 *    conversions/labels, making future extensions (e.g., meters) simple.
 * --------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // ----- CONFIG -----
        Units.Current  = UnitSystem.Metric;   // choose Imperial or Metric output
        double weightKg = 70;                 // user weight for calorie calc

        // ----- SAMPLE DATA -----
        var activities = new List<Activity>
        {
            new Running (new DateTime(2025, 6, 18), 30, 3.0,  weightKg),
            new Cycling (new DateTime(2025, 6, 18), 45, 15.0, weightKg),
            new Swimming(new DateTime(2025, 6, 18), 40, 30,   weightKg)
        };

        // ----- DISPLAY INDIVIDUAL SUMMARIES -----
        foreach (var act in activities)
            Console.WriteLine(act.GetSummary());

        Console.WriteLine(new string('-', 75));

        // ----- DAILY TOTALS (showing off aggregation) -----
        double totalMinutes  = activities.Sum(a => a.DurationMinutes);
        double totalMiles    = activities.Sum(a => a.GetDistance());
        double totalCalories = activities.Sum(a => a.GetCalories());

        double totalDistanceDisplay = Units.Current == UnitSystem.Imperial
            ? totalMiles
            : Units.MilesToKm(totalMiles);

        Console.WriteLine($"TOTAL {activities.First().Date:dd MMM yyyy} – "
                        + $"{totalMinutes} min, "
                        + $"{totalDistanceDisplay:0.00} {Units.DistanceUnit}, "
                        + $"{totalCalories:0} kcal");
    }
}

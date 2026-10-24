using System;
using System.Collections.Generic;
using System.Diagnostics;

// Klassen för ett enskilt mätvärde
public class Measurement
{
    public DateTime Time { get; set; }
    public double Kw { get; set; }
}

// Klassen för laddstationen
public class ChargingStation
{
    public string Name { get; set; } = "";
    private List<Measurement> _measurements = new List<Measurement>();

    public void AddMeasurement(Measurement m)
    {
        _measurements.Add(m);
    }

    public double TotalEnergyKwh()
    {
        double total = 0;
        foreach (var m in _measurements)
        {
            total += m.Kw * 0.25;
        }
        return total;
    }
}

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
class Program
{
    static void Main(string[] args)
    {
        // Skapa stationen AC-01
        var station = new ChargingStation { Name = "AC-01" };

        // 1. Skapa det första mätvärdet i variabeln 'm'
        var m = new Measurement { Time = new DateTime(2026, 10, 13, 8, 0, 0), Kw = 11.0 };

        // 2. Lägg till mätvärdet i stationen
        station.AddMeasurement(m);

        // 3. Lägg till de övriga mätvärdena
        station.AddMeasurement(new Measurement { Time = new DateTime(2026, 10, 13, 8, 15, 0), Kw = 11.0 });
        station.AddMeasurement(new Measurement { Time = new DateTime(2026, 10, 13, 8, 30, 0), Kw = 10.0 });
        station.AddMeasurement(new Measurement { Time = new DateTime(2026, 10, 13, 8, 45, 0), Kw = 6.0 });

        // 4. Steg 6: Ändra effekten på variabeln 'm' till 0
        m.Kw = 0;

        // 5. Skriv ut resultatet (blir nu 6,8 kWh istället för 9,5 kWh)
        Console.WriteLine($"{station.Name} har levererat {station.TotalEnergyKwh():F1} kWh");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        var station = new ChargingStation("AC-01", 11.0);

        try
        {
            Console.WriteLine($"Startar laddning på {station.Id}...");
            station.StartCharging(); // Gör stationen upptagen
            Console.WriteLine("Laddning startad framgångsrikt.");

            Console.WriteLine("Försöker starta en laddning till...");
            station.StartCharging(); // Kastar InvalidOperationException
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
        }
    }
}

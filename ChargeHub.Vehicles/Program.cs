using System;

class Program
{
    static void Main(string[] args)
    {
        // Skapa bil 1: 75 kWh batteri, startar på 20 procent
        var car = new Vehicle("Bil 1", 75.0, 20.0);

        // Ladda 30 kWh
        car.Charge(30.0);
        Console.WriteLine($"Efter 30 kWh är bilen på {car.Percent}%");

        // Ladda 50 kWh till
        car.Charge(50.0);
        Console.WriteLine($"Efter 50 kWh till är bilen på {car.Percent}%");
    }
}
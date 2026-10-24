using System;

public class Vehicle
{
    public string Id { get; }
    public double BatteryKwh { get; }
    
    private double _percent;
    public double Percent 
    { 
        get { return _percent; }
        private set 
        {
            if (value < 0) _percent = 0;
            else if (value > 100) _percent = 100;
            else _percent = value;
        }
    }

    public Vehicle(string id, double batteryKwh, double initialPercent)
    {
        Id = id;
        BatteryKwh = batteryKwh;
        Percent = initialPercent; // Använder egenskapen så gränserna gäller direkt
    }

    public void Charge(double kwh)
    {
        if (kwh <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kwh), "Du måste ladda mer än 0 kWh.");
        }

        // Räkna ut hur många procent laddningen motsvarar
        // Exempel: (30 / 75) * 100 = 40%
        double addedPercent = (kwh / BatteryKwh) * 100;
        
        // Öka Percent (reglerna i 'set' stoppar den från att gå över 100)
        Percent += addedPercent;
    }
}
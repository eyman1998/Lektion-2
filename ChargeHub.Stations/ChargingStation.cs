using System;

public class ChargingStation
{
    public string Id { get; }
    public double MaxKw { get; }
    public bool IsAvailable { get; private set; } = true;

    public ChargingStation(string id, double maxKw)
    {
        if (maxKw <= 0)
        {
            throw new ArgumentException("MaxKw måste vara större än 0.");
        }
        Id = id;
        MaxKw = maxKw;
    }

    public void StartCharging()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Stationen är redan upptagen.");
        }
        IsAvailable = false;
    }

    public void StopCharging()
    {
        IsAvailable = true;
    }
}
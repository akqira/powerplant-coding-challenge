namespace EnergyPlanner.Domain.Entities;

public class GasolinePowerPlant : BasePowerPlant
{
    public GasolinePowerPlant(string name, double efficiency, double pmax, double pmin, double gasCostPerMwh) : base(name, efficiency, pmax, pmin)
    {
        GasCostPerMwh = gasCostPerMwh;
    }

    public double GasCostPerMwh { get; set; }
}
namespace EnergyPlanner.Domain.Entities;

public class TurboJetPowerPlant : BasePowerPlant
{
    public TurboJetPowerPlant(string name, double efficiency, double pmax, double pmin, double kerosineCostPerMwh) : base(name, efficiency, pmax, pmin)
    {
        kerosineCostPerMwh = kerosineCostPerMwh;
    }

    public double kerosineCostPerMwh { get; set; }
}
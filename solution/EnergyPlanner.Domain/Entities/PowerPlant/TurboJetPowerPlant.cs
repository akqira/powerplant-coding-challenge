using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class TurboJetPowerPlant : BasePowerPlant
{
    public TurboJetPowerPlant(string name, double efficiency, double pmax, double pmin, double kerosinePrice) : base(name, efficiency, pmax, pmin)
    {
        if (kerosinePrice < 0)
        {
            throw new PowerPlantCostMustBeGreaterThanZeroException();
        }
        this.KerosinePrice = kerosinePrice;
    }

    public double KerosinePrice { get; set; }

    public override double CostPerMwh()
    {
        return KerosinePrice / Efficiency;
    }
}
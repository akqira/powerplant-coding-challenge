using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class TurboJetPowerPlant : BasePowerPlant
{
    public TurboJetPowerPlant(string name, decimal efficiency, decimal pmax, decimal pmin, decimal kerosinePrice) : base(name, efficiency, pmax, pmin)
    {
        if (kerosinePrice < 0)
        {
            throw new PowerPlantCostMustBeGreaterThanZeroException();
        }
        this.KerosinePrice = kerosinePrice;
    }

    public decimal KerosinePrice { get; set; }

    public override decimal CostPerMwh()
    {
        return KerosinePrice / Efficiency;
    }
}
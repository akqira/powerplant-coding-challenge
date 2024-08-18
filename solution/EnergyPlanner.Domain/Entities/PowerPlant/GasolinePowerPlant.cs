using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class GasolinePowerPlant : BasePowerPlant
{
    public GasolinePowerPlant(string name, decimal efficiency, decimal pmax, decimal pmin, decimal gasPrice) : base(name, efficiency, pmax, pmin)
    {
        if (gasPrice < 0)
        {
            throw new PowerPlantCostMustBeGreaterThanZeroException();
        }

        GasPrice = gasPrice;
    }

    public decimal GasPrice { get; set; }

    public override decimal CostPerMwh()
    {
        return GasPrice / Efficiency;
    }
}
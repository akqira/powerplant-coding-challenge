using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class GasolinePowerPlant : BasePowerPlant
{
    public GasolinePowerPlant(string name, double efficiency, double pmax, double pmin, double gasPrice) : base(name, efficiency, pmax, pmin)
    {
        if (gasPrice < 0)
        {
            throw new PowerPlantCostMustBeGreaterThanZeroException();
        }

        GasPrice = gasPrice;
    }

    public double GasPrice { get; set; }

    public override double CostPerMwh()
    {
        return GasPrice / Efficiency;
    }
}
using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class WindPowerPlant : BasePowerPlant
{
    public WindPowerPlant(string name, double pmax, double windPercentage) : base(name, efficiency: 1, pmax)
    {
        if (windPercentage < 0 || windPercentage > 100)
        {
            throw new WindPowerPlantWindPercentageException();
        }

        WindPercentage = windPercentage;
    }
    public double WindPercentage { get; set; }

    public override double CostPerMwh()
    {
        return 0;
    }
}

using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class WindPowerPlant : BasePowerPlant
{
    public WindPowerPlant(string name, decimal pmax, decimal windPercentage) : base(name, efficiency: 1, pmax)
    {
        if (windPercentage < 0 || windPercentage > 100)
        {
            throw new WindPowerPlantWindPercentageException();
        }

        WindPercentage = windPercentage;
        Pmax = pmax * (windPercentage / 100);        
    }
    public decimal WindPercentage { get; set; }

    public override decimal CostPerMwh()
    {
        return 0;
    }

}

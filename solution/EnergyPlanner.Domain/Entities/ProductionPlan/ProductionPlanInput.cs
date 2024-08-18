using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class ProductionPlanInput
{
    public ProductionPlanInput(double load)
    {
        if (load <= 0)
        {
            throw new ProductionPlanInputLoadException();
        }

        Load = load;
        PowerPlants = new List<BasePowerPlant>();
    }

    public double Load { get; }
    public List<BasePowerPlant> PowerPlants { get; }

    public void AddPowerPlant(BasePowerPlant powerPlant)
    {
        if (PowerPlants.Any(p => p.Name == powerPlant.Name))
        {
            throw new ProductionPlanInputPowerPlantMustBeUniqueException();
        }

        PowerPlants.Add(powerPlant);
    }

    public void RemovePowerPlantByName(string powerPlantName)
    {
        if (!PowerPlants.Any(p => p.Name == powerPlantName))
        {
            throw new ProductionPlanInputPowerPlantMissingException();
        }
        PowerPlants.RemoveAll(p => p.Name == powerPlantName);
    }
}
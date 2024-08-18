using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public class ProductionRequest
{
    public ProductionRequest(decimal load)
    {
        if (load <= 0)
        {
            throw new ProductionPlanInputLoadException();
        }

        Load = load;
        PowerPlants = new List<BasePowerPlant>();
    }

    public decimal Load { get; }
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
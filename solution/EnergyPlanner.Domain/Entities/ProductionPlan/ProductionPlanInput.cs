namespace EnergyPlanner.Domain.Entities;

public class ProductionPlanInput
{
    public ProductionPlanInput(double load)
    {        
        Load = load;
        PowerPlants = new List<BasePowerPlant>();
    }

    public double Load { get; }
    public List<BasePowerPlant> PowerPlants { get; }

    public void AddPowerPlant(BasePowerPlant powerPlant)
    {
        PowerPlants.Add(powerPlant);
    }

    public void RemovePowerPlantByName(string powerPlantName)
    {
        PowerPlants.RemoveAll(p => p.Name == powerPlantName);
    }
}
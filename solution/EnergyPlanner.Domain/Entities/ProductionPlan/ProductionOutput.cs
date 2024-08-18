
namespace EnergyPlanner.Domain.Entities;

public class ProductionOutput
{
    public ProductionOutput(string powerPlantName, decimal generatedLoad)
    {
        PowerPlantName = powerPlantName;
        GeneratedLoad = Math.Round(generatedLoad, 1);
    }
    public string PowerPlantName { get; set; }

    public decimal GeneratedLoad { get; set; }
}

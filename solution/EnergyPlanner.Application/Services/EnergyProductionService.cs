
using EnergyPlanner.Domain.Interfaces;
using EnergyPlanner.Domain.Entities;

namespace EnergyPlanner.Application.Services;

public class EnergyProductionService : IEnergyProductionService
{
    public ProductionPlan GenerateProductionPlan(ProductionPlanInput productionPlanInput)
    {

        var productionPlan = new ProductionPlan(name: null, productionPlanInput);

        // Order power plants by merit
        var powerPlantsByMerite = OrderPowerPlantsByMerite(productionPlanInput.PowerPlants);

        foreach (var powerPlant in powerPlantsByMerite)
        {
            
        }
        
        return productionPlan;
    }

    public List<BasePowerPlant> OrderPowerPlantsByMerite(List<BasePowerPlant> powerPlants)
    {
        return powerPlants.OrderBy(p => p.CostPerMwh()).ToList();
    }
}

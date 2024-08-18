using EnergyPlanner.Domain.Entities;
namespace EnergyPlanner.Domain.Interfaces;

public interface IEnergyProductionService
{
    ProductionPlan GenerateProductionPlan(ProductionRequest productionRequest);

    List<BasePowerPlant> OrderPowerPlantsByMerite(List<BasePowerPlant> powerPlants);
}

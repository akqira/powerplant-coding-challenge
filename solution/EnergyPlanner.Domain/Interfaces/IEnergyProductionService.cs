using EnergyPlanner.Domain.Entities;
namespace EnergyPlanner.Domain.Interfaces;

public interface IEnergyProductionService
{
    ProductionPlan GenerateProductionPlan(ProductionPlanInput productionPlanInput);

    List<BasePowerPlant> OrderPowerPlantsByMerite(List<BasePowerPlant> powerPlants);
}

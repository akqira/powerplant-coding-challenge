using EnergyPlanner.Domain.Entities;
namespace EnergyPlanner.Domain.Interfaces;

public interface IEnergyProductionService
{
    double GenerateProductionPlan(ProductionPlanInput productionPlanInput);
}

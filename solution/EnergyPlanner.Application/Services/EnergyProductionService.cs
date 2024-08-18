
using EnergyPlanner.Domain.Interfaces;
using EnergyPlanner.Domain.Entities;
using EnergyPlanner.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace EnergyPlanner.Application.Services;

public class EnergyProductionService : IEnergyProductionService
{
    private readonly ILogger<EnergyProductionService> _logger;

    public EnergyProductionService(ILogger<EnergyProductionService> logger)
    {
        _logger = logger;
    }

    public ProductionPlan GenerateProductionPlan(ProductionRequest productionRequest)
    {
        var productionPlan = new ProductionPlan();

        try
        {
            // Order power plants by merit
            var powerPlantsByMerite = OrderPowerPlantsByMerite(productionRequest.PowerPlants);

            var remainingLoad = productionRequest.Load;

            foreach (var powerPlant in powerPlantsByMerite)
            {
                if (remainingLoad <= 0)
                {
                    break;
                }

                decimal allocatedPowerFromPowerPlant = 0;
                try
                {
                    allocatedPowerFromPowerPlant = powerPlant.AllocatedPower(remainingLoad);
                }
                catch (PowerPlantPminExceededException)
                {
                    _logger.LogWarning("Power plant {powerPlantName} cannot allocate power for load {load} because Pmin is exceeded", powerPlant.Name, remainingLoad);
                }

                remainingLoad -= allocatedPowerFromPowerPlant;
                productionPlan.ProductionOutputs.Add(new ProductionOutput(powerPlant.Name, allocatedPowerFromPowerPlant));
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while generating production plan");
            throw;
        }

        return productionPlan;
    }

    public List<BasePowerPlant> OrderPowerPlantsByMerite(List<BasePowerPlant> powerPlants)
    {
        try
        {
            return powerPlants.OrderBy(p => p.CostPerMwh()).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while ordering power plants by merit");
            throw;
        }
    }
}

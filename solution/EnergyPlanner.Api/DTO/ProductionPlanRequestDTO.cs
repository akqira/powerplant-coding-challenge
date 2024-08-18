using EnergyPlanner.Domain.Entities;
using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Api.DTO;


public class PowerPlantRequestDTO
{
    public int Load { get; set; }
    public FuelDTO Fuels { get; set; }
    public List<PowerPlantDTO> Powerplants { get; set; }

    public ProductionPlanInput ToProductionPlanInput()
    {
        var productionPlanInput = new ProductionPlanInput(Load);

        foreach (var powerPlant in Powerplants)
        {
            var basePowerPlant = powerPlant.Type switch
            {
                "gasfired" => new GasolinePowerPlant(
                    name: powerPlant.Name,
                    efficiency: powerPlant.Efficiency,
                    pmax: powerPlant.Pmax,
                    pmin: powerPlant.Pmin,
                    gasPrice: Fuels.GasEuroMWh),

                "turbojet" => new TurboJetPowerPlant(
                    name: powerPlant.Name,
                    efficiency: powerPlant.Efficiency,
                    pmax: powerPlant.Pmax,
                    pmin: powerPlant.Pmin,
                    kerosinePrice: Fuels.KerosineEuroMWh),

                "windturbine" => (BasePowerPlant)new WindPowerPlant(
                    name: powerPlant.Name,
                    pmax: powerPlant.Pmax,
                    windPercentage: Fuels.WindPercentage),

                _ => throw new PowerPlantTypeNotImplementedException()
            };

            productionPlanInput.AddPowerPlant(basePowerPlant);
        }

        return productionPlanInput;
    }
}

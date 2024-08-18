using EnergyPlanner.Application.Services;
using EnergyPlanner.Domain.Entities;
using EnergyPlanner.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;

namespace EnergyPlanner.Tests;

public class ProductionPlanTests
{

    [Fact]
    public void ProductionPlanInputLoadMustBeGreatherThanZero()
    {
        // act & assert
        var exception = Assert.Throws<ProductionPlanInputLoadException>(() =>
        new ProductionRequest(load: 0));

        Assert.Equal("Production Plan Load must be greater than zero", exception.Message);
    }

    [Fact]
    public void ProductionPlanNameIsMandatory()
    {
        // act & assert
        var productionPlan = new ProductionPlan(name: null);

        Assert.Equal($"Production Plan {DateTime.Now}", productionPlan.Name);
    }


    [Fact]
    public void ProductionPlanInputPowerPlantsMustBeUnique()
    {
        // arrange
        var productionPlanInput = new ProductionRequest(load: 100);
        var powerPlant = new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 10);
        productionPlanInput.AddPowerPlant(powerPlant);

        // act & assert
        var exception = Assert.Throws<ProductionPlanInputPowerPlantMustBeUniqueException>(() =>
        productionPlanInput.AddPowerPlant(powerPlant));

        Assert.Equal("Power plant must be unique", exception.Message);
    }

    [Fact]
    public void ProductionPlanInputRemovePowerPlantMustExist()
    {
        // arrange
        var productionPlanInput = new ProductionRequest(load: 100);
        var powerPlant = new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 10);
        productionPlanInput.AddPowerPlant(powerPlant);

        // act
        productionPlanInput.RemovePowerPlantByName("Gasoline");

        // assert
        Assert.Empty(productionPlanInput.PowerPlants);
    }

    [Fact]
    public void ProductionPlanInputRemovePowerPlantMustExistException()
    {
        // arrange
        var productionPlanInput = new ProductionRequest(load: 100);
        var powerPlant = new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 10);
        productionPlanInput.AddPowerPlant(powerPlant);

        // act
        var exception = Assert.Throws<ProductionPlanInputPowerPlantMissingException>(() => productionPlanInput.RemovePowerPlantByName("Gasoline2")
        );

        // assert
        Assert.Equal("Power plant missing", exception.Message);
    }

    [Fact]
    public void GenerateProductionPlanCannotExceedRequestedLoad()
    {
        // arrange
        var productionPlanInput = new ProductionRequest(load: 100);
        var powerPlant = new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 10);
        productionPlanInput.AddPowerPlant(powerPlant);

        // act
        var productionPlan = new ProductionPlan(name: "Test");

        // assert

        Assert.Equal(100, productionPlanInput.Load);
        Assert.True(productionPlan.ProductionOutputs.Sum(p => p.GeneratedLoad) <= productionPlanInput.Load);
    }

    [Fact]
    public void MeriteOrderMustBeCorrect()
    {
        // arrange
        var mockLogger = new Mock<ILogger<EnergyProductionService>>();
        var powerPlant1 = new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 10);
        var powerPlant2 = new TurboJetPowerPlant(name: "TurboJet1", efficiency: 0.3m, pmax: 100, pmin: 0, kerosinePrice: 10);
        var powerPlant3 = new GasolinePowerPlant(name: "Gasoline3", efficiency: 0.5m, pmax: 100, pmin: 0, gasPrice: 5);
        var powerPlant4 = new WindPowerPlant(name: "Wind", pmax: 100, windPercentage: 50);
        var powerPlants = new List<BasePowerPlant> { powerPlant1, powerPlant2, powerPlant3, powerPlant4 };

        // act
        var energyProductionService = new EnergyProductionService(mockLogger.Object);
        var orderedPowerPlants = energyProductionService.OrderPowerPlantsByMerite(powerPlants);

        // assert
        Assert.Equal(4, orderedPowerPlants.Count);
        Assert.Equal("Wind", orderedPowerPlants[0].Name);
        Assert.Equal("Gasoline3", orderedPowerPlants[1].Name);
        Assert.Equal("Gasoline", orderedPowerPlants[2].Name);
        Assert.Equal("TurboJet1", orderedPowerPlants[3].Name);
    }
}
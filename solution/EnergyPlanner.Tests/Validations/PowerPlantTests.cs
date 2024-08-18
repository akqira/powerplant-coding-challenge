using EnergyPlanner.Domain.Entities;
using EnergyPlanner.Domain.Exceptions;
namespace EnergyPlanner.Tests;

public class PowerPlantTests
{
    [Fact]
    public void PowerPlantNameIsMandatory()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantMissingNameException>(() => new GasolinePowerPlant("", 0.5, 100, 0, 10));

        Assert.Equal("Power plant name is mandatory", exception.Message);
    }


    [Fact]
    public void PowerPlantPmaxMustBeGreaterThanPmin()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantPmaxMustBeGreaterThanPminException>(() => new GasolinePowerPlant(name: "Gasoline", efficiency: 1, pmax: 50, pmin: 100, gasPrice: 10));

        Assert.Equal("Power plant Pmax must be greater than Pmin", exception.Message);
    }

    [Fact]
    public void PowerPlantEfficiencyMustBeGreaterThanZero()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantEfficiencyMustBeGreaterThanZeroException>(() => new GasolinePowerPlant(name: "Gasoline", efficiency: -0.1, pmax: 50, pmin: 1, gasPrice: 10));

        Assert.Equal("Power plant efficiency must be greater than zero", exception.Message);
    }

    [Fact]
    public void PowerPlantEfficiencyCannotBeGreaterThanOne()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantEfficiencyMaxValueException>(() => new GasolinePowerPlant(name: "Gasoline", efficiency: 1.1, pmax: 50, pmin: 40, gasPrice: 10));

        Assert.Equal("Power plant efficiency cannot be greater than 1", exception.Message);
    }

    [Fact]
    public void GasolinePowerPlantCostCannotBeNegative()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantCostMustBeGreaterThanZeroException>(() => new GasolinePowerPlant(name: "Gasoline", efficiency: 0.5, pmax: 50, pmin: 40, gasPrice: -10));

        Assert.Equal("Power plant gas cost must be greater than zero", exception.Message);
    }

    [Fact]
    public void WindPowerPlantMustHaveValidWindPercentage()
    {
        // act & assert
        var exception = Assert.Throws<WindPowerPlantWindPercentageException>(() => new WindPowerPlant(name: "Wind", pmax: 50, windPercentage: 101));

        Assert.Equal("Wind power plant wind percentage must be between 0 and 100", exception.Message);
    }


}


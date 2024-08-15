using EnergyPlanner.Domain.Entities;
using EnergyPlanner.Domain.Exceptions;
namespace EngieProduction.Tests;

public class PowerPlantTests
{
    [Fact]
    public void PowerPlantNameIsMandatory()
    {
        // act & assert
        var exception = Assert.Throws<PowerPlantMissingNameException>(() => new GasolinePowerPlant("", 0.5, 100, 0, 10));

        Assert.Equal("Power plant name is mandatory", exception.Message);
    }
}
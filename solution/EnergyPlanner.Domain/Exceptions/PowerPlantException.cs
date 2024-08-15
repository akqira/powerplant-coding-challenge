namespace EnergyPlanner.Domain.Exceptions;

public class PowerPlantMissingNameException : Exception
{
    public PowerPlantMissingNameException() : base("Power plant name is mandatory")
    {

    }
}

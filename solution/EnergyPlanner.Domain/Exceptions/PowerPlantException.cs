namespace EnergyPlanner.Domain.Exceptions;

public class PowerPlantMissingNameException : Exception
{
    public PowerPlantMissingNameException() : base("Power plant name is mandatory")
    {

    }
}

public class PowerPlantPminMustBeGreaterThanZeroException : Exception
{
    public PowerPlantPminMustBeGreaterThanZeroException() : base("Power plant Pmin must be greater than zero")
    {

    }
}

public class PowerPlantPmaxMustBeGreaterThanPminException : Exception
{
    public PowerPlantPmaxMustBeGreaterThanPminException() : base("Power plant Pmax must be greater than Pmin")
    {

    }
}

public class PowerPlantEfficiencyMustBeGreaterThanZeroException : Exception
{
    public PowerPlantEfficiencyMustBeGreaterThanZeroException() : base("Power plant efficiency must be greater than zero")
    {

    }
}

public class PowerPlantEfficiencyMaxValueException : Exception
{
    public PowerPlantEfficiencyMaxValueException() : base("Power plant efficiency cannot be greater than 1")
    {

    }
}

public class PowerPlantCostMustBeGreaterThanZeroException : Exception
{
    public PowerPlantCostMustBeGreaterThanZeroException() : base("Power plant gas cost must be greater than zero")
    {

    }
}

public class WindPowerPlantWindPercentageException : Exception
{
    public WindPowerPlantWindPercentageException() : base("Wind power plant wind percentage must be between 0 and 100")
    {

    }
}

public class PowerPlantPminExceededException : Exception
{
    public PowerPlantPminExceededException() : base("Power plant Pmin exceeded")
    {

    }
}

public class PowerPlantTypeNotImplementedException : Exception
{
    public PowerPlantTypeNotImplementedException() : base("Power plant type not implemented")
    {

    }
}
namespace EnergyPlanner.Domain.Exceptions;

public class ProductionPlanException : Exception
{
    public ProductionPlanException(string message) : base(message)
    {
    }
}

public class ProductionPlanInputLoadException : ProductionPlanException
{
    public ProductionPlanInputLoadException() : base("Production Plan Load must be greater than zero")
    {
    }
}

public class ProductionPlanInputPowerPlantMustBeUniqueException : ProductionPlanException
{
    public ProductionPlanInputPowerPlantMustBeUniqueException() : base("Power plant must be unique")
    {
    }
}

public class ProductionPlanInputPowerPlantMissingException : Exception
{
    public ProductionPlanInputPowerPlantMissingException() : base("Power plant missing")
    {
    }
}

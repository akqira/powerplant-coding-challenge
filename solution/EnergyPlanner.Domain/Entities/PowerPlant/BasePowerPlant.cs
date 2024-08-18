using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public abstract class BasePowerPlant
{
    public BasePowerPlant(string name, decimal efficiency, decimal pmax, decimal pmin = 0, decimal powerAllocationPrecision = 0.1m)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new PowerPlantMissingNameException();
        }

        if (pmin < 0)
        {
            throw new PowerPlantPminMustBeGreaterThanZeroException();
        }

        if (pmax <= pmin)
        {
            throw new PowerPlantPmaxMustBeGreaterThanPminException();
        }

        if (efficiency <= 0)
        {
            throw new PowerPlantEfficiencyMustBeGreaterThanZeroException();
        }

        if (efficiency > 1)
        {
            throw new PowerPlantEfficiencyMaxValueException();
        }

        Name = name;
        Efficiency = efficiency;
        Pmax = pmax;
        Pmin = pmin;
        PowerAllocationPrecision = powerAllocationPrecision;
    }

    public string Name { get; set; }
    public decimal Efficiency { get; set; }
    public decimal Pmin { get; set; }
    public decimal Pmax { get; set; }
    public decimal PowerAllocationPrecision { get; init; }
    public abstract decimal CostPerMwh();
    public virtual decimal AllocatedPower(decimal? load)
    {
        decimal allocatedPower = 0;
        if (load == null)
        {
            return allocatedPower;
        }

        if (load.Value < Pmin)
        {
            throw new PowerPlantPminExceededException();
        }

        if (load.Value > Pmax)
        {
            load = Pmax;
        }

        allocatedPower = Math.Round(load.Value / PowerAllocationPrecision) * PowerAllocationPrecision;
        Pmax -= allocatedPower;
        return allocatedPower;
    }
}

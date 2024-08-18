using EnergyPlanner.Domain.Exceptions;

namespace EnergyPlanner.Domain.Entities;

public abstract class BasePowerPlant
{
    public BasePowerPlant(string name, double efficiency, double pmax, double pmin = 0)
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
    }

    public string Name { get; set; }
    public double Efficiency { get; set; }
    public double Pmin { get; set; }
    public double Pmax { get; set; }
    public abstract double CostPerMwh();
    public double AllocatePower(double? load)
    {
        double allocatedPower = 0;
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

        allocatedPower = load.Value;
        Pmax -= allocatedPower;
        return allocatedPower;
    }
}

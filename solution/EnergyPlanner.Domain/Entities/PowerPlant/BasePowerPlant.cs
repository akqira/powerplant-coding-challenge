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

        Name = name;
        Efficiency = efficiency;
        Pmax = pmax;
        Pmin = pmin;
    }

    public string Name { get; set; }
    public double Efficiency { get; set; }
    public double Pmin { get; set; }
    public double Pmax { get; set; }
}

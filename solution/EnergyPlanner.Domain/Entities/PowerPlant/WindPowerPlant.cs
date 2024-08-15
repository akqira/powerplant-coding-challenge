namespace EnergyPlanner.Domain.Entities;

public class WindPowerPlant : BasePowerPlant
{
    public WindPowerPlant(string name, double pmax, double windPercentage) : base(name, efficiency: 1, pmax)
    {
        WindPercentage = windPercentage;
    }
    public double WindPercentage { get; set; }
}

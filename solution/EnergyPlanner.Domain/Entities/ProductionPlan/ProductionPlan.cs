namespace EnergyPlanner.Domain.Entities;

public class ProductionPlan
{
    public ProductionPlan()
    {
        ProductionPlanUnits = new List<ProductionPlanUnit>();
    }

    public double RequestedLoad { get; set; }
    public List<ProductionPlanUnit> ProductionPlanUnits { get; set; }
    public double TotalLoadGenerated => ProductionPlanUnits.Sum(x => x.GeneratedLoad);
}

namespace EnergyPlanner.Domain.Entities;

public class ProductionPlan
{
    public ProductionPlan(string name, ProductionPlanInput productionPlanInput)
    {
        Name = string.IsNullOrWhiteSpace(name) ? $"Production Plan {DateTime.Now}" : name;
        ProductionPlanUnits = new List<ProductionPlanUnit>();
        this.productionPlanInput = productionPlanInput;
    }

    public string Name { get; set; }
    public DateTime GeneratedAt { get { return DateTime.Now; } }
    public ProductionPlanInput productionPlanInput { get; set; }
    public List<ProductionPlanUnit> ProductionPlanUnits { get; set; }
    public double TotalLoadGenerated => ProductionPlanUnits.Sum(x => x.GeneratedLoad);
}

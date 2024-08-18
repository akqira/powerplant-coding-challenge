namespace EnergyPlanner.Domain.Entities;

public class ProductionPlan
{
    public ProductionPlan(string? name = null)
    {
        Name = string.IsNullOrWhiteSpace(name) ? $"Production Plan {DateTime.Now}" : name;
        ProductionOutputs = new List<ProductionOutput>();
    }
    public string Name { get; set; }

    public DateTime GeneratedAt { get { return DateTime.Now; } }

    public List<ProductionOutput> ProductionOutputs { get; set; }

}
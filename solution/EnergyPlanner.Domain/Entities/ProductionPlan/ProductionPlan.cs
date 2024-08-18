namespace EnergyPlanner.Domain.Entities;

public class ProductionPlan
{
    public ProductionPlan(decimal requestedLoad, string? name = null)
    {
        if (requestedLoad <= 0)
        {
            throw new ArgumentException("Requested load must be greater than 0");
        }

        Name = string.IsNullOrWhiteSpace(name) ? $"Production Plan {DateTime.Now}" : name;
        ProductionOutputs = new List<ProductionOutput>();
        RequestedLoad = requestedLoad;
    }
    public string Name { get; set; }


    public List<ProductionOutput> ProductionOutputs { get; set; }

    public decimal RequestedLoad { get; init; }
    public decimal TotalGeneratedLoad => ProductionOutputs.Sum(x => x.GeneratedLoad);

}
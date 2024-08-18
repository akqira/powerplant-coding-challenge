namespace EnergyPlanner.Domain.Entities;

public class ProductionPlanCalculator
{
    public ProductionPlanCalculator(string name, ProductionRequest productionRequest)
    {
        this.ProductionRequest = productionRequest;
    }
      
    public ProductionRequest ProductionRequest { get; set; }
    public ProductionPlan ProductionPlan { get; }
}

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ProductionPlanController : ControllerBase
{

    private readonly ILogger<ProductionPlanController> _logger;

    public ProductionPlanController(ILogger<ProductionPlanController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string GetProductionPlan()
    {
        _logger.LogInformation("GetProductionPlan called");
        return "Ok";
    }
}
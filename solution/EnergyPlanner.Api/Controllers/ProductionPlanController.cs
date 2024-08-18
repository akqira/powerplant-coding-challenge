using EnergyPlanner.Api.DTO;
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

    [HttpPost]
    public IActionResult GetProductionPlan(PowerPlantRequestDTO productionPlanRequest)
    {

        _logger.LogInformation("GetProductionPlan called");
        return Ok(new { Plan = productionPlanRequest.ToProductionPlanInput() });
    }
}
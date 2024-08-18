using System.Text.Json;
using EnergyPlanner.Api.Converters;
using EnergyPlanner.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPlanner.Api;

[Route("[controller]")]
[ApiController]
public class ProductionPlanController : ControllerBase
{
    private readonly IEnergyProductionService _energyProductionService;

    private readonly ILogger<ProductionPlanController> _logger;

    public ProductionPlanController(ILogger<ProductionPlanController> logger, IEnergyProductionService energyProductionService)
    {
        _logger = logger;
        _energyProductionService = energyProductionService;
    }

    [HttpPost]
    public IActionResult GetProductionPlan(ProductionPlanRequestDTO productionPlanRequest)
    {
        try
        {
            _logger.LogInformation("Received request to get production plan for load {load}", productionPlanRequest.Load);

            var productionPlan = _energyProductionService.GenerateProductionPlan(productionPlanRequest.ToProductionPlanInput());

            // create ProductionOutputDTO
            var productionOutputDTOs = productionPlan.ProductionOutputs.Select(po => new ProductionOutputDTO
            {
                PowerPlantName = po.PowerPlantName,
                GeneratedLoad = po.GeneratedLoad
            }).ToList();

            // Create JsonSerializerOptions and add the custom converter
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new DecimalJsonConverter() }
            };

            return Ok(JsonSerializer.Serialize(new UnifiedApiResponse
            {
                Success = true,
                Data = productionPlan
            }, options));

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while generating production plan");
            return Ok(new UnifiedApiResponse
            {
                Success = false,
                ErrorCode = "SERVER_ERROR",
                ErrorMessage = "Error while generating production plan",
                ErrorDetails = ex.Message
            });
        }
    }
}
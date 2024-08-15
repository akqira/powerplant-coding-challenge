using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ProductionPlanController : ControllerBase{
    [HttpGet]
    public string GetProductionPlan(){
        return "Ok";
    }
}
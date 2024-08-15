using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class PowerPlantController : ControllerBase{
    [HttpGet]
    public string GetPowerPlant(){
        return "Ok";
    }
}
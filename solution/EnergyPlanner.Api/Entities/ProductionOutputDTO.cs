using System.Text.Json.Serialization;
using EnergyPlanner.Api.Converters;

namespace EnergyPlanner.Api;

public class ProductionOutputDTO
{
    public string PowerPlantName { get; set; }

    [JsonConverter(typeof(DecimalJsonConverter))]
    public decimal GeneratedLoad { get; set; }
}
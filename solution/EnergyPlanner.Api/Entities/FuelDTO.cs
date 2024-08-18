
using System.Text.Json.Serialization;

namespace EnergyPlanner.Api;
public class FuelDTO
{
    [JsonPropertyName("gas(euro/MWh)")]
    public decimal GasEuroMWh { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    public decimal KerosineEuroMWh { get; set; }

    [JsonPropertyName("co2(euro/ton)")]
    public decimal Co2EuroTon { get; set; }

    [JsonPropertyName("wind(%)")]
    public decimal WindPercentage { get; set; }
}

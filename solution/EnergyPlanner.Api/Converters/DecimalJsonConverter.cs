using System.Text.Json;
using System.Text.Json.Serialization;
namespace EnergyPlanner.Api.Converters;
public class DecimalJsonConverter : JsonConverter<decimal>
{
  public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        // Use the numeric value with formatting to one decimal place
        writer.WriteNumberValue(Math.Round(value, 1));
    }

    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Handle deserialization if necessary
        if (reader.TokenType == JsonTokenType.Number &&
            reader.TryGetDecimal(out decimal value))
        {
            return value;
        }
        throw new JsonException();
    }
}

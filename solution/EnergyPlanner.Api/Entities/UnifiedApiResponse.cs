namespace EnergyPlanner.Api;

public class UnifiedApiResponse
{
    public string ApiVersion { get; set; } = "1.0";
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string ErrorDetails { get; set; } = string.Empty;
    public bool Success { get; set; } = false;
    public object? Data { get; set; } = null;

}

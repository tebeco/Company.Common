namespace Company.Apis;

public class CompanyHealthChecksOptions
{
    public const string ReadinessProbeEndpointPath = "/health/ready";
    public const string LivenessProbeEndpointPath = "/health/live";
    
    public const string LivenessHealthChecksTag = "live";
}
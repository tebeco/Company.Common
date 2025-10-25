using Company.Apis.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

// ReSharper disable once CheckNamespace
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.AspNetCore.Routing;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CompanyHealthChecksEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapCompanyHealthChecks(this IEndpointRouteBuilder app)
    {
        // Adding health checks endpoints to applications in non-development environments has security implications.
        // See https://aka.ms/dotnet/aspire/healthchecks for details before enabling these endpoints in non-development environments.
        // All health checks must pass for app to be considered ready to accept traffic after starting
        app.MapHealthChecks(CompanyHealthChecksOptions.ReadinessProbeEndpointPath);

        // Only health checks tagged with the "live" tag must pass for app to be considered alive
        app.MapHealthChecks(CompanyHealthChecksOptions.LivenessProbeEndpointPath, new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains(CompanyHealthChecksOptions.LivenessHealthChecksTag)
        });

        return app;
    }
}
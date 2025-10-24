using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace Company.Apis;

public static class CompanyHealthChecksHostBuilderExtensions
{
    public static IHostApplicationBuilder AddCompanyHealthChecks(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), [CompanyHealthChecksOptions.LivenessHealthChecksTag]);

        return builder;
    }
}
using Company.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Company.Apis;

public static class CompanyApisHostBuilderExtensions
{
    public static IHostApplicationBuilder AddApis(this IHostApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails();
        builder.Services.AddOpenApi();

        builder.Services.AddInfrastructure();

        builder.AddCompanyHealthChecks();

        return builder;
    }
}
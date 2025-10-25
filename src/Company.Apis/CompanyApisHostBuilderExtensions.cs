using Company.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// ReSharper disable once CheckNamespace
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.Hosting;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CompanyApisHostBuilderExtensions
{
    public static IHostApplicationBuilder AddCompanyApis(this IHostApplicationBuilder builder)
    {
        builder.Services.AddProblemDetails();
        builder.Services.AddOpenApi();

        builder.Services.AddInfrastructure();
        builder.AddCompanyHealthChecks();

        return builder;
    }
}
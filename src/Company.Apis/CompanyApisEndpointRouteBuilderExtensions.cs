using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;

// ReSharper disable once CheckNamespace
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.AspNetCore.Routing;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CompanyApisEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapCompanyApis(this IEndpointRouteBuilder app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.MapCompanyHealthChecks();

        return app;
    }
}
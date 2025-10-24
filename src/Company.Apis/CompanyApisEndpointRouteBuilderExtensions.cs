using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Company.Apis;

public static class CompanyApisEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapCompanyApis(this IEndpointRouteBuilder app)
    {
        app.MapOpenApi();
        app.MapCompanyHealthChecks();

        return app;
    }
}
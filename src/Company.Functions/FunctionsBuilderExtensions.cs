using Company.Common;
using Microsoft.Extensions.Hosting;

namespace Company.Functions;

public static class FunctionsHostBuilderExtensions
{
    public static IHostApplicationBuilder AddFunctionApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();
        
        return builder;
    }
}
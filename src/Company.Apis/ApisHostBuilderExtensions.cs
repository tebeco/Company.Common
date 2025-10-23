using Company.Common;
using Microsoft.Extensions.Hosting;

namespace Company.Apis;

public static class ApisHostBuilderExtensions
{
    public static IHostApplicationBuilder AddFunctionApp(this IHostApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();
        
        return builder;
    }
}
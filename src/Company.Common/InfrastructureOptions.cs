using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Company.Common;

public class InfrastructureOptions
{
    public const string SectionName = "Infrastructure";
    public const string LocalEnvironment = "local";
    
    public required string Service { get; set; }
    
    public required string Environment { get; set; }
    
    public required string Version { get; set; }
}

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddOptions<InfrastructureOptions>()
            .BindConfiguration(InfrastructureOptions.SectionName)
            .PostConfigure<IHostEnvironment>((options, env) =>
            {
                if (env.IsDevelopment())
                {
                    options.Environment = InfrastructureOptions.LocalEnvironment;
                }
            });
        
        return services;
    }
}
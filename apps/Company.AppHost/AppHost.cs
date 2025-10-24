var builder = DistributedApplication.CreateBuilder(args);

builder.AddOpenTelemetryCollector("opentelemetry-collector")
        .WithConfig("opentelemetry-collector-config.yaml")
        .WithAppForwarding();

var cache = builder.AddRedis("cache");
var postgres = builder.AddRedis("postgres");
var mongo = builder.AddRedis("mongo");

var webapi = builder.AddProject<Projects.Company_WebApi>("webapi")
        .WithHttpHealthCheck("/health")
        .WithExternalHttpEndpoints()
        .WithReference(cache)
        .WaitFor(cache)
        ;

var functionService = builder.AddProject<Projects.Company_FunctionApp>("functionapp")
        .WithExternalHttpEndpoints()
        .WithReference(cache)
        .WaitFor(cache)
        ;


// builder.AddProject<Projects.Company_Web>("webfrontend")
//     .WithExternalHttpEndpoints()
//     .WithHttpHealthCheck("/health")
//     .WithReference(cache)
//     .WaitFor(cache)
//     .WithReference(apiService)
//     .WaitFor(apiService);

builder.Build().Run();
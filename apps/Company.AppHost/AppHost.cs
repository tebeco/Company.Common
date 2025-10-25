var builder = DistributedApplication.CreateBuilder(args);


var lgtm = builder.AddContainer("lgtm", "grafana/otel-lgtm")
    .WithEndpoint(3000, 3000, "http", "Grafana")
    .WithEndpoint(5317, 4317, "grpc")
    .WithEndpoint(5318, 4318, "http")
    .WithLifetime(ContainerLifetime.Persistent);

builder.AddOpenTelemetryCollector("opentelemetry-collector")
        .WithConfig("opentelemetry-collector-config.yaml")
        .WithAppForwarding()
        .WaitFor(lgtm)
        ;

var cache = builder.AddRedis("cache");
var postgres = builder.AddRedis("postgres");
var mongo = builder.AddRedis("mongo");

var webapi = builder.AddProject<Projects.Company_WebApi>("webapi")
        .WithHttpHealthCheck(Company.Apis.HealthChecks.CompanyHealthChecksOptions.ReadinessProbeEndpointPath)
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
using Company.Apis;

var builder = WebApplication.CreateBuilder(args);

builder.AddCompanyApis();

var app = builder.Build();

app.UseExceptionHandler();

app.MapCompanyApis();

app.Run();

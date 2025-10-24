using Company.Apis;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseExceptionHandler();

app.MapCompanyApis();

app.Run();

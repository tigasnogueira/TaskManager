
using TaskManager.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfiguration()
    .AddDependencyInjectionConfiguration()
    .AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();

app.Run();

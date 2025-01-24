using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotenv.net;
using System;
using src.UseCases;
using src.Infrastructure.Adapters;

DotEnv.Load();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<GetLoan>();
builder.Services.AddHttpClient<LoanManagementAdapter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run($"http://localhost:{port}");
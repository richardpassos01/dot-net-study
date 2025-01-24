using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotenv.net;
using src.Api.DependencyInjection;
using System;

DotEnv.Load();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run($"http://localhost:{port}");
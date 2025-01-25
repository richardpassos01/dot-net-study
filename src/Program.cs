using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotenv.net;
using src.Api.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using src.Infrastructure.Database;

DotEnv.Load();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();

var connectionString = "Data Source=application.db";
builder.Services.AddDbContext<RelationalDbContext>(options =>
    options.UseSqlite(connectionString));

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
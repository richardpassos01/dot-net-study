using System;
using Microsoft.AspNetCore.Builder;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Carregar o arquivo de configuração .env
DotEnv.Load();
var port = Environment.GetEnvironmentVariable("PORT");

var app = builder.Build();

// Configure um endpoint GET que retorna "Hello World"
app.MapGet("/api/helloworld", () => "Hello World");

// Usar a porta configurada no .env
app.Run($"http://localhost:{port}");
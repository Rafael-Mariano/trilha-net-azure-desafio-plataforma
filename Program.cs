using Microsoft.EntityFrameworkCore;
using TrilhaNetAzureDesafio.Context;

var builder = WebApplication.CreateBuilder(args);

// temporario
var conn = builder.Configuration.GetConnectionString("ConexaoPadrao");
Console.WriteLine($">>> CONNECTION: {conn}");

// temporario

// Add services to the container.
builder.Services.AddDbContext<RHContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using System.Text.Json;
using Application;
using Infrastructure;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services
    .Configure<JsonSerializerOptions>(options =>
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    })
    .AddSingleton<CosmosClient>(_ =>
    {
        string? connectionString = builder.Configuration.GetConnectionString("CosmosDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "The CosmosDb connection string is not defined in local.settings.json");
        }

        return new CosmosClientBuilder(connectionString).Build();
    });

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movie Adviser Service",
        Version = "v1"
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

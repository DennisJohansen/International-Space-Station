using InternationalSpaceStation.Core;
using InternationalSpaceStation.Interfaces;
using InternationalSpaceStation.Middleware;
using InternationalSpaceStation.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "InternationalSpaceStation API"
    });
});

// Get settings
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Setup DI
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddSingleton<IStatisticalService, StatisticalService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // basic header key authorization middleware
    app.UseKeyAuthorization();
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

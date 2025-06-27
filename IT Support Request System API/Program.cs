using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ITSupportSystem.Interfaces;
using ITSupportSystem.Logic;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IITsupportLogic, ITSupportLogic>();
builder.Services.AddScoped<IAiAnalysisLogic, AiAnalysisLogic>();

builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IT Support API",
        Version = "1.0.0",
        Description = "IT Support API is used to process user input with AI to Create functionality that, " +
        "after receiving user input (system or module, description, steps to reproduce, expected result, and priority), " +
        "automatically uses AI to generate a report based on users request title and classify the request type "


    })
);
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
var webApplication = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "IT Support API v1.0.0");
        options.RoutePrefix = string.Empty;
    });
}

// Use HTTPS redirection and authorization
webApplication.UseHttpsRedirection();
webApplication.UseAuthorization();

// Map controllers to routes
webApplication.MapControllers();

webApplication.Run();

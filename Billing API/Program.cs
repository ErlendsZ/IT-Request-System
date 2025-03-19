using BillingAPI.Interfaces;
using BillingAPI.Logic;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IBillingLogic, BillingLogic>();

builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Billing API",
        Version = "1.0.0",
        Description = "Billing API is used in company \"XYZ Inc.\" for order processing and payment handling." +
        "When the billing service processes order, it sends the order to an appropriate payment gateway. If the order " +
        "is processed successfully by the payment gateway, the billing service creates a receipt and returns it in response." +
        "In testing enviroment we assume that payment is always succesful (method ProcessPayment returns always true). <br>" +
        "<b>TESTING:</b> Create new Order. Call processPayment endpoint with same orderId as was used for order creation" +
        "If everything scessful you should see receipt returned."

    })
);
var webApplication = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Billing API v1.0.0");
        options.RoutePrefix = string.Empty;
    });
}

// Use HTTPS redirection and authorization
webApplication.UseHttpsRedirection();
webApplication.UseAuthorization();

// Map controllers to routes
webApplication.MapControllers();

webApplication.Run();

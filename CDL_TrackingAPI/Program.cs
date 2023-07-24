using System.Net;
using Azure.Core;
using CDL_TrackingAPI;
using CDL_TrackingAPI.DbContexts;
using CDL_TrackingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DBConnection>(options => options.UseSqlServer("Server=172.24.32.210;Database=Xcelerator;User ID=CDL_OrderTracker;Password=nyc!123xyz;Integrated Security=False;Encrypt=false;TrustServerCertificate=true"));
builder.Services.AddDbContext<DBConnection>(options => options.UseSqlServer("Server=172.24.32.132;database=XceleratorTest;User ID=CDL_Tracking;Password=nyc!123xyz;max pool size=200;Integrated Security=True;"));

builder.Services.AddScoped<ICdlTrackerRepository, CdlTrackerRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
        policy =>
        {
            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors("corsapp");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


app.MapGet("/Monitoring", () => "Hello World!");

app.MapGet("/api/Tracking", async (ICdlTrackerRepository cdl,string orderTrackingId) =>
{
    try
    {
        TrackingResults result = await cdl.Tracking(orderTrackingId);

        //return result == null ? NotFoundResult : (result);
        if (result.TrackingInformation is null)
        {
            return Results.NotFound("NotFound");
        }
        else
        {

            return Results.Ok(result);
        }
    }catch
    (Exception ex)
    { return Results.BadRequest("Failed"); }
}).WithName("APi For Tracking Page "); ;

app.MapPut("/api/Notification", async (ICdlTrackerRepository cdl, [FromBody] NotificationModel notification) =>
{
    try
    {
        Boolean result = await cdl.Notification(notification);

        
        if (!result)
        {
            return Results.StatusCode(304);
        }
        else
        {

            return Results.Ok(result);
        }
    }
    catch
    (Exception ex)
    { 
        return Results.BadRequest("Failed");
    }
}).WithName("APi Notification ");

app.MapPut("/api/DeliveryInstruction", async (ICdlTrackerRepository cdl, [FromBody] DriverInstruction driver) =>
{
    try
    {
        Boolean result = await cdl.DeliveryInstruction(driver);


        if (!result)
        {
            return Results.StatusCode(304);
        }
        else
        {

            return Results.Ok(result);
        }
    }
    catch
    (Exception ex)
    {
        return Results.BadRequest("Failed");
    }
}).WithName("APi Driver Instruction ");


app.Run();


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CDLTrackerApi;
using CDLTracker.Service.Api.DbContexts;
using CDLTracker.Service.Api.Repository;
using Serilog;
using CDLTracker.Service.Api.Models;

try
{
    #region Configurations
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateBootstrapLogger();

    Log.Logger.ForContext("Component", "CDLTracker.Service.Api");

    builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("corsapp",
            policy =>
            {
                policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            });
    });

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //Configure DB
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString_CDLTracking")));

    //Configure automapper
    //IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    //builder.Services.AddSingleton(mapper);
    //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    //Adding ReportRepository,PartnerRepository repositories
    IServiceCollection serviceCollection = builder.Services.AddScoped<ICdlTrackerRepository, CdlTrackerRepository>();
    var app = builder.Build();

    //Adding Serilog's request logging streamlines
    //app.UseSerilogRequestLogging();
    #endregion

    #region APIs

    //app.MapGet("api/cdltracker/GetCdlOrderTrackingInfo", async ([FromServices] ICdlTrackerRepository CdlTrackerRepository, string orderTrackingId, bool isOrderTrackingid) =>
    //{
    //    ResponseDto response = new ResponseDto();

    //    try
    //    {
    //        response.Result = await CdlTrackerRepository.GetCdlOrderTrackingInfo(orderTrackingId, isOrderTrackingid);
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Information("{Message}", $"GetCdlOrderTrackingInfo api called successfully..." +
    //                               $"OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");
    //    }
    //    catch (Exception ex)
    //    {
    //        response.IsSuccess = false;
    //        response.ErrorMessages = new List<string>() { ex.ToString() };
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Error("{Message}", $"GetCdlOrderTrackingInfo api call failed. " +
    //                                $"Error Message: {response.ErrorMessages}...OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");

    //    }

    //    return response;
    //});



    app.MapGet("api/Tracking", async (string orderTrackingId) =>
    {
        CdlTrackerRepository res = new CdlTrackerRepository();



        return res.Tracking(orderTrackingId);
    });


    //app.MapGet("api/cdltracker/GetCdlOrderScans", async ([FromServices] ICdlTrackerRepository CdlTrackerRepository, string orderTrackingId) =>
    //{
    //    //ResponseDto response = new ResponseDto();

    //    //try
    //    //{
    //    //    response.Result = await CdlTrackerRepository.GetCdlOrderScans(orderTrackingId);
    //    //    if (response.Result == null)
    //    //    {
    //    //        throw new Exception();
    //    //    }
    //    //    Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Information("{Message}", $"GetCdlOrderScans api called successfully..." +
    //    //                           $"OrderTrackingId:{orderTrackingId}");
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    response.IsSuccess = false;
    //    //    response.ErrorMessages = new List<string>() { ex.ToString() };
    //    //    response.DisplayMessage = "The TarackingID/Refrence Number cannot found";
    //    //    Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Error("{Message}", $"GetCdlOrderScans api call failed. " +
    //    //                            $"Error Message: {response.ErrorMessages}...OrderTrackingId:{orderTrackingId}");

    //    //}

    //    return response;
    //});

    //app.MapGet("api/cdltracker/GetCdlGeolocation", async ([FromServices] ICdlTrackerRepository CdlTrackerRepository, string orderTrackingId, bool isOrderTrackingid) =>
    //{
    //    ResponseDto response = new ResponseDto();

    //    try
    //    {
    //        response.Result = await CdlTrackerRepository.GetCdlGeolocation(orderTrackingId, isOrderTrackingid);
    //        if (response.Result==null)
    //        {
    //            throw new Exception();
    //        }
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Information("{Message}", $"GetCdlGeolocation api called successfully..." +
    //                               $"OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");
    //    }
    //    catch (Exception ex)
    //    {
    //        response.IsSuccess = false;
    //        response.ErrorMessages = new List<string>() { ex.ToString() };
    //        response.DisplayMessage = "The TarackingID/Refrence Number cannot found";
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Error("{Message}", $"GetCdlGeolocation api call failed. " +
    //                                $"Error Message: {response.ErrorMessages}...OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");

    //    }

    //    return response;
    //});

    //app.MapGet("api/cdltracker/GetCdlDeliverlocation", async ([FromServices] ICdlTrackerRepository CdlTrackerRepository, string orderTrackingId, bool isOrderTrackingid) =>
    //{
    //    ResponseDto response = new ResponseDto();

    //    try
    //    {
    //        response.Result = await CdlTrackerRepository.GetCdlDriverlocation(orderTrackingId, isOrderTrackingid);
    //        if (response.Result==null)
    //        {
    //            throw new Exception();
    //        }
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Information("{Message}", $"GetCdlGeolocation api called successfully..." +
    //                               $"OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");
    //    }
    //    catch (Exception ex)
    //    {
    //        response.IsSuccess = false;
    //        response.ErrorMessages = new List<string>() { ex.ToString() };
    //        response.DisplayMessage = "The TarackingID/Refrence Number cannot found";
    //        Log.Logger.ForContext("Component", "CDLTracker.Service.Api").Error("{Message}", $"GetCdlDriverlocation api call failed. " +
    //                                $"Error Message: {response.ErrorMessages}...OrderTrackingId:{orderTrackingId}...isOrderTrackingid:{isOrderTrackingid}");

    //    }

    //    return response;
    //});
    #endregion

    #region Development env settings and app run
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
}
    
    app.UseCors("corsapp");
    app.Run();

    #endregion
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
using Azure.Identity;
using FluentValidation.AspNetCore;
using Ftl.Backoffice.API;
using Ftl.Backoffice.Application;
using Ftl.Backoffice.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Serilog;
using System.Configuration;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

//create the logger and setup your sinks, filters and properties
Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
    .WriteTo.AzureTableStorage(builder.Configuration.GetValue<string>("logconnection") ?? Environment.GetEnvironmentVariable("LogsStorageConnectionString"))
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    builder.Host.UseSerilog();
    var origins = builder.Configuration.GetValue<string>("CorsOrigins").Split(";");

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins(origins).AllowAnyHeader()
                                                      .AllowAnyMethod();
                          });
    });


    builder.Services.AddApplicationServices();
    builder.Services.AddDataAccessServices(builder.Configuration);
    builder.Services.AddApiServices();

    // Add services to the container.
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

    builder.Services.AddControllers()
        .AddFluentValidation();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
        c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}")
    );

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseCors(MyAllowSpecificOrigins);
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
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

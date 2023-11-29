using Microsoft.AspNetCore.Identity;
using Web.Data;
using Web.Data.Infrastructures;
using Web.Services;
using WebApplication1.Controllers.Security;
using MediatR;
using WebApplication1.Controllers.Logger;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDataBaseFactory, DataBaseFactory>();

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddDbContext<WebContext>();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<WebContext>();

builder.Services.AddCustomSecurity(builder.Configuration);

//Log.Logger = new LoggerConfiguration()
//           .Enrich.FromLogContext()
//           .Enrich.WithExceptionDetails()
//           .WriteTo.Console()
//           .WriteTo.Debug()
//           .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
//           {
//               AutoRegisterTemplate = true,
//               IndexFormat = "Serilog-dev-022022"
//           }).CreateLogger();   

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.Enrich.FromLogContext()
                 .Enrich.WithMachineName()
                 .WriteTo.Console()
                 .WriteTo.Debug()
                 .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                 {
                     AutoRegisterTemplate = true,
                     IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-" +
                     $"{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                     NumberOfReplicas = 1,
                     NumberOfShards = 2,
                 })
                 .Enrich.WithProperty("Environnement", context.HostingEnvironment.EnvironmentName)
                 .ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(SecurityCors.DEFAULT_POLICY);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

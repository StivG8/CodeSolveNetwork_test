using CodeSolveNetwork.Api;
using CodeSolveNetwork.Api.Configuration;
using CodeSolveNetwork.Common.Settings;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.Settings.Settings;
using CodeSolveNetwork.Context;
using CodeSolveNetwork.Context.Setup;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);

var services = builder.Services;
// Add services to the container.

services.AddHttpContextAccessor();//to store corelation id

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppControllerAndViews();

services.RegisterServices(builder.Configuration);    //adding bootstrapper services


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppControllerAndViews();

DbInitializer.Execute(app.Services);

logger.Information("The CodeSolveNetwork.API has started");

app.Run();

logger.Information("The CodeSolveNetwork.API has stopped");

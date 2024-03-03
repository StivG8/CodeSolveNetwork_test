using CodeSolveNetwork.Api;
using CodeSolveNetwork.Api.Configuration;
using CodeSolveNetwork.Common.Settings;
using CodeSolveNetwork.Services.Logger.Logger;
using CodeSolveNetwork.Services.Settings.Settings;
using CodeSolveNetwork.Context;
using CodeSolveNetwork.Context.Setup;
using CodeSolveNetwork.Context.Seeder.Seeds;
using CodeSolveNetwork.Services.Settings;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);

var services = builder.Services;
// Add services to the container.

services.AddHttpContextAccessor();//to store corelation id

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings, identitySettings);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppAuth(identitySettings);

services.AddAppControllerAndViews();

services.RegisterServices(builder.Configuration);    //adding bootstrapper services


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

DbInitializer.Execute(app.Services);

DbSeeder.Execute(app.Services);

logger.Information("The CodeSolveNetwork.API has started");

app.Run();

logger.Information("The CodeSolveNetwork.API has stopped");

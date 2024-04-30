using CodeSolveNetwork.Web;
using CodeSolveNetwork.Web.Pages.Auth.Services;
using CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Services;
using CodeSolveNetwork.Web.Providers;
using CodeSolveNetwork.Web.Services;
using Blazored.LocalStorage;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CodeSolveNetwork.Web.Pages.Solutions.Services;
using CodeSolveNetwork.Web.Pages.Tasks.Services;
using CodeSolveNetwork.Web.Pages.TaskCategories.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Settings.ApiRoot) });

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
builder.Services.AddScoped<ISolutionService, SolutionService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskCategoryService, TaskCategoryService>();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();

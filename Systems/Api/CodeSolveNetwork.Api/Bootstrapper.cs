﻿using CodeSolveNetwork.Api.Settings;
using CodeSolveNetwork.Context.Seeder;
using CodeSolveNetwork.Services.Actions;
using CodeSolveNetwork.Services.Logger;
using CodeSolveNetwork.Services.ProgrammingLanguages;
using CodeSolveNetwork.Services.RabbitMq;
using CodeSolveNetwork.Services.Settings;
using CodeSolveNetwork.Services.Solutions;
using CodeSolveNetwork.Services.TaskCategories;
using CodeSolveNetwork.Services.Tasks;
using CodeSolveNetwork.Services.UserAccount;

namespace CodeSolveNetwork.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service, IConfiguration configuration = null)
        {
            service
                .AddMainSettings()
                .AddLogSettings()
                .AddSwaggerSettings()
                .AddIdentitySettings()
                .AddAppLogger()
                .AddDbSeeder()
                .AddApiSpecialSettings()
                .AddProgrammingLanguageService()
                .AddSolutionService()
                .AddTaskCategoryService()
                .AddTaskService()
                .AddRabbitMq()
                .AddActions()
                .AddUserAccountService();

            return service;
        }
    }

}

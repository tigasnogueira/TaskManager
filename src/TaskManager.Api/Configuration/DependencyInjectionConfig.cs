using System.ComponentModel.DataAnnotations;
using TaskManager.Api.Interfaces;
using TaskManager.Api.Services;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // API
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserTaskService, UserTaskService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();

            // Data
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<TaskManagerContext>();

            return builder;
        }
    }
}

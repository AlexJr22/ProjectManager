using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Mappings;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;
using ProjectManager.Infrastructure.Repositories;

namespace ProjectManager.CrossCutting.Ioc;

public static class AddInfrastructure
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        string strConnection
    )
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(strConnection));

        services.AddAutoMapper(typeof(ProfileMapping).Assembly);

        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        //services.AddScoped<ITaskService, TaskService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}

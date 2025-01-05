using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Mappings;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.CrossCutting.Ioc;

public static class AddInfrastructure
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        string strConnection
    )
    {
        services.AddDbContext<AppDbContext>(options =>
               options.UseSqlite(strConnection));

       services.AddAutoMapper(typeof(ProfileMapping));

        return services;
    }
}

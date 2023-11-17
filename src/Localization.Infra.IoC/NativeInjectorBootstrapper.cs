using Localization.Application.DTOs;
using Localization.Domain.Repositories;
using Localization.Domain.UoW;
using Localization.Infra.Data.Context;
using Localization.Infra.Data.Repositories;
using Localization.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Localization.Infra.IoC;

public static class NativeInjectorBootStrapper 
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<AppDbContext>(opts => {
            opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            sqlOpts => 
            { 
                sqlOpts.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            });
        });
    }

    public static void RegisterServices(this IServiceCollection services) 
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ResponseDTO<>).Assembly));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ILocalizationRepository, LocalizationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

    }
}
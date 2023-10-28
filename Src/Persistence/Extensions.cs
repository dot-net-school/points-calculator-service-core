using Application.Common;
using Application.Common.Interfaces;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.UnitOfWork;

namespace Persistence;

public static class Extensions
{
    public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MainDb"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ILanguageCertificateRepository, LanguageCertificateRepository>();
        services.AddScoped<ILanguageScoreRepository, LanguageScoreRepository>();
        services.AddScoped<IAgeScoreRepository, AgeScoreRepository>();
        services.AddScoped<IJobExperienceScoreRepository, JobExperienceScoreRepository>();
        services.AddScoped<IMaritalStatusScoreRepository, MaritalStatusScoreRepositroy>();
        services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
        return services;

    }
}
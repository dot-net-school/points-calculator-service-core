using System.Reflection;
using Application.Common.Interfaces;
using Application.Common.Validation;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Extensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AgeScoreStrategy> ();
        services.AddScoped<JobExperienceScoreStrategy> (); 
        services.AddScoped<LanguageScoreCalculator> ();
        services.AddScoped<MaritalStatusScoreStrategy> ();
        services.AddScoped<UniversityDegreeCalculator> ();
        services.AddScoped<Application.Services.TotalScoreCalculator> ();
        
        services.AddScoped<List<IScoreStrategy>>(provider => new List<IScoreStrategy>
        {
            provider.GetRequiredService<AgeScoreStrategy>(),
            provider.GetRequiredService<JobExperienceScoreStrategy>(),
            provider.GetRequiredService<LanguageScoreCalculator>(),
            provider.GetRequiredService<MaritalStatusScoreStrategy>(),
            provider.GetRequiredService<UniversityDegreeCalculator>(),
        });
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<IValidatorBase>();
        return services;
    }
}
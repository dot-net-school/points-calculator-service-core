using System.Reflection;
using Application.Common.Interfaces;
using Application.Common.Validation;
using Application.LanguageCertificate.Create;
using Application.LanguageCertificate.Delete;
using Application.LanguageCertificate.Update;
using Application.Score.Language.Commands.Create;
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
        services.AddScoped<IScoreCalculatorService<int, int>, AgeScoreCalculatorService>();

        services.AddScoped<IScoreCalculatorService<int, int>, JobExperienceScoreCalculatorService>();
        services.AddScoped<IScoreCalculatorService<int, int>, MaritalStatusScoreCalculatorService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<IValidatorBase>();
        return services;
    }
}
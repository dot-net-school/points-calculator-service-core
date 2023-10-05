﻿using Application.Common.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class Extensions
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IScoreCalculatorService<int, int>, AgeScoreCalculatorService>();

        services.AddScoped<IScoreCalculatorService<int, int>, JobExperienceScoreCalculatorService>();
        services.AddScoped<IScoreCalculatorService<int, int>, MaritalStatusScoreCalculatorService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
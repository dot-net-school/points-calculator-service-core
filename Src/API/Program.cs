using API.Options;
using FluentValidation.AspNetCore;
using Shared;

//using Persistence;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddControllers();
        
        //TODO is it option pattern?
        ServiceRegistration.RegisterServices(builder.Services, builder.Configuration);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseSharedApplicationBuilder();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
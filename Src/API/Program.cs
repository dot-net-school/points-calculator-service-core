using Infrastructure;
//using Persistence;
using System.Reflection;
using Application;
using Persistence;

namespace API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
      
        builder.Services.AddControllers();
        builder.Services.RegisterPersistenceServices(builder.Configuration)
            .RegisterPresentationServices()
            .RegisterInfrastructureServices(builder.Configuration)
            .RegisterApplicationServices(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
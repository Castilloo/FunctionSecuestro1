using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.DataContext;
using SecuestroBienes.Repositories;
using System;

[assembly: FunctionsStartup(typeof(SecuestroBienes.Startup))]
namespace SecuestroBienes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            var configurationRoot = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            
            builder.Services.AddDbContext<SecuestroDbContext>(options =>
            {
                var connectionString = configurationRoot.GetConnectionString("ConnectionDatabase");
                options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        // Configura la resiliencia ante errores transitorios
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,         // Número máximo de intentos de reconexión
                        maxRetryDelay: TimeSpan.FromSeconds(30), // Retardo máximo entre intentos
                        errorNumbersToAdd: null);
                    });
            });
            
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ISecuestroBienRepository, SecuestroBienRepository>();
            builder.Services.AddTransient<IBandejaTrabajoRepository, BandejaTrabajoRepository>();
        }
    }
}

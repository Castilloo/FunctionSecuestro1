using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.DataContext;
using SecuestroBienes.Repositories;

[assembly: FunctionsStartup(typeof(SecuestroBienes.Startup))]
namespace SecuestroBienes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<SecuestroDbContext>(options =>
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = config.GetConnectionString("ConnectionDatabase");
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddTransient<IUnitOFWork, UnitOfWork>();
            builder.Services.AddTransient<ISecuestroBienRepository, SecuestroBienRepository>();
            builder.Services.AddTransient<IBandejaTrabajoRepository, BandejaTrabajoRepository>();
        }
    }
}

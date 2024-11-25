using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Statistic.Infrastructure.Context
{
    public class StatisticContextFactory : IDesignTimeDbContextFactory<StatisticContext>
    {
        public StatisticContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/appsettings.json",
                              optional: false,
                              reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<StatisticContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Statistic.Infrastructure"));

            return new StatisticContext(optionsBuilder.Options);
        }
    }
}
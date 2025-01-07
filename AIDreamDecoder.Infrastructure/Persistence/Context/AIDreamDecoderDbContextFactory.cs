using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Persistence.Context
{
    public class AIDreamDecoderDbContextFactory: IDesignTimeDbContextFactory<AIDreamDecoderDbContext>
    {
        public AIDreamDecoderDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create options
            var optionsBuilder = new DbContextOptionsBuilder<AIDreamDecoderDbContext>()
                  .UseNpgsql(connectionString);

            return new AIDreamDecoderDbContext(optionsBuilder.Options);
        }
    }
}

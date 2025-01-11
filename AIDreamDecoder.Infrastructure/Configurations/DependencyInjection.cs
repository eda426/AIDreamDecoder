using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AIDreamDecoder.Infrastructure.Persistence;
using AIDreamDecoder.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AIDreamDecoder.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(typeof(Repository<>)); // Generic Repository'yi servis olarak ekliyoruz
            services.AddScoped<DreamService>(); // DreamService'i servis olarak ekliyoruz

            return services;
        }
    }
}

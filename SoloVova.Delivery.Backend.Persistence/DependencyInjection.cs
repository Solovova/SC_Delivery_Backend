using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoloVova.Delivery.Backend.Application.Interfaces;

namespace SoloVova.Delivery.Backend.Persistence{
    public static class DependencyInjection{
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration){
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DeliveryDbContext>(options => { options.UseSqlite(connectionString); });
            services.AddScoped<IDeliveryDbContext>(provider =>
                provider.GetService<DeliveryDbContext>());
            return services;
        }
    }
}
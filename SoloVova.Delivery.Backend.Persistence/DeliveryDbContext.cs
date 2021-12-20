using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Domain;
using SoloVova.Delivery.Backend.Persistence.EntityTypeConfigurations;

namespace SoloVova.Delivery.Backend.Persistence{
    public class DeliveryDbContext : DbContext, IDeliveryDbContext{
        public DbSet<Packages> Packages{ get; set; }

        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new DeliveryConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
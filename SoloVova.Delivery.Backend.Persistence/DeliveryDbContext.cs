using Microsoft.EntityFrameworkCore;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Domain;
using SoloVova.Delivery.Backend.Persistence.EntityTypeConfigurations;

namespace SoloVova.Delivery.Backend.Persistence{
    public class DeliveryDbContext : DbContext, IDeliveryDbContext{
        public DbSet<Package> Package{ get; set; }
        public DbSet<Address> Address{ get; set; }
        

        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new PackagesConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
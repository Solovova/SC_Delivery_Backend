using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Persistence.EntityTypeConfigurations{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>{
        public void Configure(EntityTypeBuilder<Address> builder){
            builder.HasKey(address => address.Id);
            builder.HasIndex(address => address.Id).IsUnique();
            builder.Property(address => address.Name).HasMaxLength(250);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Persistence.EntityTypeConfigurations{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Packages>{
        public void Configure(EntityTypeBuilder<Packages> builder){
            builder.HasKey(package => package.Id);
            builder.HasIndex(package => package.Id).IsUnique();
            builder.Property(package => package.Title).HasMaxLength(250);
        }
    }
}
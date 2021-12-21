using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoloVova.Delivery.Backend.Domain;

namespace SoloVova.Delivery.Backend.Persistence.EntityTypeConfigurations{
    public class PackagesConfiguration : IEntityTypeConfiguration<Package>{
        public void Configure(EntityTypeBuilder<Package> builder){
            builder.HasKey(package => package.Id);
            builder.HasIndex(package => package.Id).IsUnique();
            builder.Property(package => package.Title).HasMaxLength(250);

            builder.HasOne(e => e.AddressFrom);
            //.WithMany(c => c.packages)
            //.IsRequired();
            //builder.HasOne<Address>(package => package.addressFrom);
            //builder.HasRequired<Address>(package => package.addressFrom);

        }
    }
}
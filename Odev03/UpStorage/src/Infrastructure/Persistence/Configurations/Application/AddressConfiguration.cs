using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            // ID
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AddressLine1).IsRequired();
            builder.Property(x => x.AddressLine2).IsRequired();


            //Veritabanında enum diye bir tip olmadığından enumun 0 1 2 döndüğünden veri tabanına bir integer olarak maplemek lazım
            builder.Property(x => x.AdressType).HasConversion<int>();
            builder.Property(x => x.AdressType).IsRequired();


            builder.Property(x => x.PostCode).IsRequired();
            builder.Property(x=>x.District).IsRequired();

            //BaseEntity konfigürasyonları

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired(false);
            builder.Property(x => x.CreatedByUserId).HasMaxLength(100);

            // ModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(100);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(100);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValueSql("0");
            builder.HasIndex(x => x.IsDeleted);

            // Relationships

            //Bir adres bir country e ait olabilir
            //one-to-one relationship
            builder.HasOne(x => x.Country)
                .WithOne(x => x.Address)
                .HasForeignKey<Country>(x => x.Id);

            //Bir adres bir city e ait olabilir
            builder.HasOne(x => x.City)
               .WithOne(x => x.Address)
               .HasForeignKey<City>(x => x.Id);

            //Bir userın birden çok kayıtlı adresi olabilir
            builder.HasOne<User>().WithMany(x => x.Adresses)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("Addresses");


        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class CarsOwnerConfiguration : IEntityTypeConfiguration<CarsOwner>
{
    public void Configure(EntityTypeBuilder<CarsOwner> builder)
    {
        builder.HasOne(tl => tl.User);


        builder.Property(tl => tl.Priority)
            .HasMaxLength(100);

        builder.Property(tl => tl.Rating)
            .HasMaxLength(5);

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaxiCompany.Core.Entities;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.FirstName)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .Property(user => user.LastName)
            .HasMaxLength(100)
            .IsRequired(false);

        builder
            .Property(user => user.Email)
            .HasMaxLength(255)
            .IsRequired(true);

        builder
            .Property(user => user.PasswordHash)
            .HasMaxLength(256)
            .IsRequired(true);

        builder
            .Property(user => user.Salt)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .Property(user => user.CreatedAt)
            .IsRequired(true);

        builder.HasData(GenerateUsers());
    }

    private List<User> GenerateUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e079"),
                FirstName = "Shoxruz",
                PhoneNumber = "+998881752200",
                Role = UserRole.Admin,
                Email = "saydshox123@gmail.com",
                PasswordHash = "12345",
                Salt = Guid.NewGuid().ToString()
            }
        };
    }
}

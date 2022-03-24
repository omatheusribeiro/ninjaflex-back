using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaFlex.Domain.Entitites;

namespace NinjaFlex.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();

            builder.Property(x => x.TypeUserId).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.DateLogin);

            builder.Property(p => p.BarCode).IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    DateCreate = DateTime.Now,
                    FirstName = "Admin",
                    LastName = "NinjaFlex",
                    Email = "admin@ninjaflex.com",
                    TypeUserId = 1,
                    Status = true,
                    BarCode = "123"
                }); ;
        }
    }
}

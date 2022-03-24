using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaFlex.Domain.Entitites;

namespace NinjaFlex.Data.EntityConfigurations
{
    public class TypeUserConfiguration : IEntityTypeConfiguration<TypeUser>
    {
        public void Configure(EntityTypeBuilder<TypeUser> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.HasData(
                new TypeUser
                {
                    Id = 1,
                    DateCreate = DateTime.Now,
                    Description = "Administrador",
                    Status = true,
                }); ;
        }
    }
}

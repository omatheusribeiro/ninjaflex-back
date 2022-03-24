using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NinjaFlex.Domain.Entitites;
using NinjaFlex.Data.EntityConfigurations;

namespace NinjaFlex.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TypeUser> TypesUser { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TypeUserConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.Services;
using NinjaFlex.Domain.Interfaces;
using NinjaFlex.Data.Context;
using NinjaFlex.Data.Repositories;

namespace NinjaFlex.Infra.DependecyInjetnction
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITypeUserRepository, TypeUserRepository>();
            services.AddScoped<ITypeUserService, TypeUserService>();

            return services;
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NinjaFlex.Application.Mappings;
using System;

namespace NinjaFlex.Api.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                    typeof(ViewModelToDomainMappingProfile));
        }
    }
}

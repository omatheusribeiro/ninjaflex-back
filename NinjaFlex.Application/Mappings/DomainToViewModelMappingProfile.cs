using AutoMapper;
using NinjaFlex.Application.ViewModels;
using NinjaFlex.Domain.Entitites;

namespace NinjaFlex.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<TypeUser, TypeUserViewModel>();
        }
    }
}

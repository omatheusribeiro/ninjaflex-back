using AutoMapper;
using NinjaFlex.Application.ViewModels;
using NinjaFlex.Domain.Entitites;

namespace NinjaFlex.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>();

            CreateMap<TypeUserViewModel, TypeUser>();
        }
    }
}

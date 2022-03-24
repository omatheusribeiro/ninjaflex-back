using NinjaFlex.Application.ViewModels;

namespace NinjaFlex.Application.Interfaces
{
    public interface ITypeUserService
    {
        Task<ResponseViewModel> GetTypeUsers(TypeUserViewModel typeUser);
        Task<ResponseViewModel> GetTypeUserById(int id);
        Task<ResponseViewModel> PutTypeUser(TypeUserViewModel typeUser);
        Task<ResponseViewModel> PostTypeUser(TypeUserViewModel typeUser);
    }
}

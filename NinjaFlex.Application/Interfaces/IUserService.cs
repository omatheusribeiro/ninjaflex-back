using NinjaFlex.Application.ViewModels;

namespace NinjaFlex.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseViewModel> GetUsers(UserViewModel user);
        Task<ResponseViewModel> GetUserById(int id);
        Task<ResponseViewModel> PutUser(UserViewModel user);
        Task<ResponseViewModel> PostUser(UserViewModel user);
        Task<ResponseViewModel> AuthenticateUser(string barCode);
    }
}

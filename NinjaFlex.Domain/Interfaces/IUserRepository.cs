using NinjaFlex.Domain.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaFlex.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(User user);
        Task<User> GetUserById(int id);
        Task<User> PutUser(User user);
        Task<User> PostUser(User user);
        Task<User> AuthenticateUser(string barCode);
    }
}

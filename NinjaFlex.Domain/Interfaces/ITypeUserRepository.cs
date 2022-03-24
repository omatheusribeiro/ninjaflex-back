using NinjaFlex.Domain.Entitites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaFlex.Domain.Interfaces
{
    public interface ITypeUserRepository
    {
        Task<IEnumerable<TypeUser>> GetTypeUsers(TypeUser? typeUser);
        Task<TypeUser> GetTypeUserById(int id);
        Task<TypeUser> PutTypeUser(TypeUser typeUser);
        Task<TypeUser> PostTypeUser(TypeUser typeUser);
    }
}

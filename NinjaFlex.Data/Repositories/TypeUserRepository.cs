using Microsoft.EntityFrameworkCore;
using NinjaFlex.Domain.Entitites;
using NinjaFlex.Domain.Interfaces;
using NinjaFlex.Data.Context;

namespace NinjaFlex.Data.Repositories
{
    public class TypeUserRepository : ITypeUserRepository
    {
        private ApplicationDbContext _context;

        public TypeUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeUser>> GetTypeUsers(TypeUser? typeUser)
        {
            return await _context.TypesUser.AsNoTracking()
                .Where(t => t.Description == typeUser.Description ||
                            t.Status == typeUser.Status).ToListAsync();
        }

        public async Task<TypeUser> GetTypeUserById(int id)
        {
            return await _context.TypesUser.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TypeUser> PutTypeUser(TypeUser typeUser)
        {
            typeUser.DateUpdate = DateTime.Now;

            _context.TypesUser.Update(typeUser);
            await _context.SaveChangesAsync();

            return typeUser;
        }

        public async Task<TypeUser> PostTypeUser(TypeUser typeUser)
        {
            typeUser.DateCreate = DateTime.Now;

            _context.TypesUser.Add(typeUser);
            await _context.SaveChangesAsync();

            return typeUser;
        }
    }
}

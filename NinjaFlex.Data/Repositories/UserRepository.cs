using Microsoft.EntityFrameworkCore;
using NinjaFlex.Domain.Entitites;
using NinjaFlex.Domain.Interfaces;
using NinjaFlex.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaFlex.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers(User user)
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.FirstName == user.FirstName ||
                            u.LastName == user.LastName ||
                            u.Email == user.Email ||
                            u.TypeUserId == user.TypeUserId ||
                            u.Status == user.Status).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }


        public async Task<User> PutUser(User user)
        {
            user.DateUpdate = DateTime.Now;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> PostUser(User user)
        {
            user.DateCreate = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> AuthenticateUser(string barCode)
        {
            return await _context.Users.AsNoTracking().Where(u => u.BarCode.ToLower() == barCode.ToLower()).FirstOrDefaultAsync();

        }
    }
}

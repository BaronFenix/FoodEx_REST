using FoodEx.Application;
using FoodEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> FindUserByLogin(string login)
        {
             return await _context.Users.Where(x => x.Login == login).Include(x => x.Role).FirstOrDefaultAsync();
        }

        public async Task<List<User>> FindUsersByRole(string roleName)
        {
            return await _context.Users.Where(x => x.Role.Name == roleName).Include(x => x.Role).ToListAsync();
        }
    }
}

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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> FindByName(string roleName)
        {
            return await _context.Roles.Where(x => x.Name == roleName).FirstOrDefaultAsync();
        }
    }
}

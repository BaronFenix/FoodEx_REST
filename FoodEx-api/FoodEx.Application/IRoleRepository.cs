using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task<Role> FindByName(string roleName);
    }
}

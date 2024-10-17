using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByLogin(string login);
        Task<List<User>> FindUsersByRole(string roleName);
    }
}

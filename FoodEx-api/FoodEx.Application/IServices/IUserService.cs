using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application.IServices
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);

        public Task RemoveUser(User user);

        public Task RemoveUserById(int id);

        public Task<User> GetUserByLogin(string login);

        public Task<User> GetUserById(int id);

        public Task EditUser(User user);

        public Task<IEnumerable<User>> GetAllUsers();

        public Task<IEnumerable<User>> GetUsersByRole(string roleName);



        public Task<Role> AddRole(Role role);

        public Task EditRole(Role role);

        public Task RemoveRole(Role role);

        public Task RemoveRoleById(int id);

    }
}

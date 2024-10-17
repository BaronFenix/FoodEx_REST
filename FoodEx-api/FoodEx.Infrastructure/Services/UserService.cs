using FoodEx.Application;
using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Domain.Enums;
using FoodEx.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UserService(ApplicationContext context)
        {
            _userRepository = new UserRepository(context);
            _roleRepository = new RoleRepository(context);
        }


        public async Task<Role> AddRole(Role role)
        {
            Role roleFromDb = await _roleRepository.FindByName(role.Name);
            if (roleFromDb != null)
                return null;

            return await _roleRepository.Insert(role);
        }

        public async Task<User> AddUser(User user)
        {
            User userFromDb = await _userRepository.FindUserByLogin(user.Login);
            if (userFromDb != null)
                return null;

            user.Role = await _roleRepository.FindByName(UserRole.User.ToString());
            return await _userRepository.Insert(user);
        }

        public async Task EditRole(Role role)
        {
            await _roleRepository.Update(role);
        }

        public async Task EditUser(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.FindAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.FindById(id);
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepository.FindUserByLogin(login);
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string roleName)
        {
            return await _userRepository.FindUsersByRole(roleName);
        }

        public async Task RemoveRole(Role role)
        {
            await _roleRepository.Delete(role);
        }

        public async Task RemoveRoleById(int id)
        {
            await _roleRepository.Delete(id);
        }

        public async Task RemoveUser(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task RemoveUserById(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}

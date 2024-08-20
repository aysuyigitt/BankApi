using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }
        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User UpdateUser(User user)
        {

            return _userRepository.UpdateUser(user);
        }

        User IUserService.DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}

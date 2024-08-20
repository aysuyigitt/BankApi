using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var userDbContext = new UserDbContext())
            {
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();
                return user;
            }
        }
        public void DeleteUser(int id)
        {
            using (var UserDbContext = new UserDbContext())
            {
                var deleteUser = GetUserById(id);
                UserDbContext.Users.Remove(deleteUser);
                UserDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var UserDbContext = new UserDbContext())
            {
                return UserDbContext.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var UserDbContext = new UserDbContext())
            {
                return UserDbContext.Users.Find(id);
            }
        }

        public User UpdateUser(User user)
        {
            using (var UserDbContext = new UserDbContext())
            {
                UserDbContext.Users.Update(user);
                return user;
            }
        }

        User IUserRepository.DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }


}



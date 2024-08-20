using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(User user);

        User UpdateUser(User user);

        User DeleteUser(int id);
    }
}

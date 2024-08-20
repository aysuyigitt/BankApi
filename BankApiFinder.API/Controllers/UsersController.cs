using BankApi.Business.Abstract;
using BankApi.Business.Concrete;
using BankApi.DataAccess;
using BankApi.Entities;
using BankApiFinder.API.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Linq;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;


        public UsersController()
        {
            _userService = new UserManager();
        }
        private List<User> _users = FakeDataUser.GetUsers(); 
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody] User user)
        {
            var customers = _users.FirstOrDefault(x => x.Id == user.Id);
            var newUser = new User();
            newUser.username = user.username;
            newUser.password = user.password;
            newUser.user_email = user.user_email;
            newUser.user_phone_number = user.user_phone_number;

            _users.Add(newUser);
            return newUser;
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var customers = _users.FirstOrDefault(x => x.Id == user.Id);
            var newUser = new User();
            newUser.username = user.username;
            newUser.password= user.password;
            newUser.user_email = user.user_email;
            newUser.user_phone_number= user.user_phone_number;

            _users.Add(newUser);  
            return newUser;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteUser= _users.FirstOrDefault(x => x.Id==id);   
            _users.Remove(deleteUser);  

            _userService.DeleteUser(id);
        }
    }
}

    

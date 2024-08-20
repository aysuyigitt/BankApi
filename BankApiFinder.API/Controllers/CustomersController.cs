using BankApi.Business.Abstract;
using BankApi.Business.Concrete;
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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController()
        {
            _customerService = new CustomerManager();
        }
        private List<Customer> _customers = FakeDataCustomer.GetCustomers();
        public List<Customer> Get()
        {
            return _customers;
        }
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var user = _customers.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            var users = _customers.FirstOrDefault(x => x.Id == customer.UserId);
            var newCustomer = new Customer();
            newCustomer.first_name = customer.first_name;
            newCustomer.last_name = customer.last_name;
            newCustomer.phone_number = customer.phone_number;
            newCustomer.customer_email = customer.customer_email;
            newCustomer.date_of_birth = customer.date_of_birth;

            _customers.Add(newCustomer);

            return newCustomer;
        }
        [HttpPut]
        public Customer Put([FromBody] Customer customer)
        {
            var users = _customers.FirstOrDefault(x => x.Id == customer.UserId);
            var newCustomer = new Customer();
            newCustomer.first_name = customer.first_name;
            newCustomer.last_name = customer.last_name;
            newCustomer.phone_number = customer.phone_number;
            newCustomer.customer_email = customer.customer_email;
            newCustomer.date_of_birth = customer.date_of_birth;


            return newCustomer;


        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteCustomer = _customers.FirstOrDefault(x => x.Id == id);
            _customers.Remove(deleteCustomer);
        }
    }
}
   
    

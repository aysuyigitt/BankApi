using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            using (var CustomerDbContext = new CustomerDbContext())
            {
                CustomerDbContext.Customers.Add(customer);
                CustomerDbContext.SaveChanges();
                return customer;
            }
        }

        public void DeleteCustomer(int id)
        {
            using (var CustomerDbContext = new CustomerDbContext())
            {
                var deletedCustomer = GetCustomerById(id);
                CustomerDbContext.Customers.Remove(deletedCustomer);
                CustomerDbContext.SaveChanges();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (var CustomerDbContext = new CustomerDbContext())
            {
                return CustomerDbContext.Customers.ToList();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var CustomerDbContext = new CustomerDbContext())
            {
                return CustomerDbContext.Customers.Find(id);
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (var CustomerDbContext = new CustomerDbContext())
            {
                CustomerDbContext.Customers.Update(customer);
                return customer;
            }
        }

        Customer ICustomerRepository.DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
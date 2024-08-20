using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {

            return _customerRepository.GetCustomerById(id);

        }

        public Customer UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        Customer ICustomerService.DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
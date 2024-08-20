using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomerById(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int id);
    }
}

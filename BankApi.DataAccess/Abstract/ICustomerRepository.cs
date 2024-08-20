using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
    public  interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        Customer GetCustomerById(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int id);
    }
}

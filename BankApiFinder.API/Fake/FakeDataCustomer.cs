using BankApi.DataAccess;
using BankApi.Entities;
using Bogus;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankApiFinder.API.Fake
{
    public class FakeDataCustomer
    {// Sabit tohum değeri
        private const int CustomerSeed = 123;

        private static List<User> _users = new List<User>();
        private static List<Customer> _customers = new List<Customer>();

        private static bool _dataGenerated = false;

        public static List<User> GetUsers()
        {
            return _users;
        }

        public static List<Customer> GetCustomers()
        {
            if (!_dataGenerated)
            {
                // Veritabanını temizle
                ClearDatabase();

                // Tohum değerini ayarla
                Randomizer.Seed = new Random(CustomerSeed);

                // Faker nesnelerini oluştur
                var customerFaker = new Faker<Customer>("tr")
                    .RuleFor(customer => customer.first_name, f => f.Name.FirstName())
                    .RuleFor(customer => customer.last_name, f => f.Name.LastName())
                    .RuleFor(customer => customer.phone_number, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(customer => customer.customer_email, (f, customer) => $"{customer.first_name.ToLower()}.{customer.last_name.ToLower()}@gmail.com")
                    .RuleFor(customer => customer.address, f => $"{f.Address.StreetAddress()}, {f.Address.City()}, Türkiye")
                    .RuleFor(customer => customer.date_of_birth, f => f.Date.Past());

                var userFaker = new Faker<User>("tr")
                    .RuleFor(user => user.user_phone_number, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(user => user.password, f => f.Internet.Password());

                using (var context = new CustomerDbContext())
                {
                    int userIdCounter = 1;
                    int customerIdCounter = 1;

                    for (int i = 0; i < 50; i++)
                    {
                        var customer = customerFaker.Generate();

                        var user = new User
                        {
                            Id = userIdCounter++, // ID'yi 1'den başlat
                            username = $"{customer.first_name} {customer.last_name}",
                            user_phone_number = customer.phone_number,
                            password = userFaker.Generate().password,
                            user_email = customer.customer_email
                        };

                        customer.User = user;
                        customer.UserId = user.Id;

                        customer.Id = customerIdCounter++; // ID'yi 1'den başlat

                        _users.Add(user);
                        _customers.Add(customer);

                        context.Users.Add(user); // Yeni kullanıcıları veritabanına ekle
                        context.Customers.Add(customer); // Yeni müşterileri veritabanına ekle
                    }

                    context.SaveChanges();
                }

                _dataGenerated = true;
            }

            return _customers;
        }

        // Veritabanını temizlemek için yeni bir metod ekleyin
        public static void ClearDatabase()
        {
            using (var context = new CustomerDbContext())
            {
                context.Users.RemoveRange(context.Users);
                context.Customers.RemoveRange(context.Customers);
                context.SaveChanges();
            }
        }
    }
}
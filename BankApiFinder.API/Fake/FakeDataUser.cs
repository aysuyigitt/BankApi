using BankApi.DataAccess;
using BankApi.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace BankApiFinder.API.Fake
{
    public class FakeDataUser
    {

        // Sabit tohum değeri
        private const int UserSeed = 123;

        private static List<User> _users = new List<User>();
        private static List<Customer> _customers = new List<Customer>();

        private static bool _dataGenerated = false;

        public static List<User> GetUsers()
        {
            if (!_dataGenerated)
            {
                _users.Clear();
                _customers.Clear();

                // Tohum değerini ayarla
                Randomizer.Seed = new Random(UserSeed);

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

                // ID sayaçlarını sıfırla
                int userIdCounter = 1;

                for (int i = 0; i < 50; i++)
                {
                    var customer = customerFaker.Generate();

                    var user = new User
                    {
                        Id = userIdCounter++, // ID'yi 1'den başlat ve artır
                        username = $"{customer.first_name} {customer.last_name}",
                        user_phone_number = customer.phone_number,
                        password = userFaker.Generate().password,
                        user_email = customer.customer_email
                    };

                    customer.User = user;
                    customer.UserId = user.Id;

                    _customers.Add(customer);
                    _users.Add(user);
                }

                // Veritabanına kaydetme işlemi
                using (var context = new UserDbContext())
                {
                    // Veritabanında kullanıcılar var mı kontrol et
                    if (!context.Users.Any())
                    {
                        foreach (var user in _users)
                        {
                            context.Users.Add(user);
                        }
                        context.SaveChanges();
                    }
                }

                // Verilerin bir kere oluşturulduğunu işaretle
                _dataGenerated = true;
            }

            return _users;
        }
    }
}
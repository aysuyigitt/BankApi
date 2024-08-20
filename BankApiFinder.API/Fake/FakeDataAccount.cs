using BankApi.DataAccess;
using BankApi.Entities;
using Bogus;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Principal;

namespace BankApiFinder.API.Fake
{
    public class FakeDataAccount
    {

        private const int CustomerSeed = 123;

        private static readonly Faker<Account> _accountFaker = new Faker<Account>("tr")

            .RuleFor(account => account.account_number, f => f.Random.Number(1000000, 9999999))
            .RuleFor(account => account.open_date, f => f.Date.Past());



        private static readonly Random random = new Random();
        private static readonly List<Customer> _customers = new List<Customer>();
        private static readonly List<Account> _accounts = new List<Account>();
        private static readonly List<Branch> _branches = new List<Branch>();
        private static readonly List<Balance> _balances = new List<Balance>();
        private static readonly List<User> _users = new List<User>();



        private static bool _dataGenerated = false;

        public static List<User> GetUsers()
        {
            return _users;
        }
        public static List<Customer> GetCustomers()
        {
            if (!_dataGenerated)
            {
                _customers.Clear();
                var users = GetUsers(); // Kullanıcıları al

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

                // ID sayaçlarını sıfırla
                int userIdCounter = 1;
                int customerIdCounter = 1;

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

                    customer.Id = customerIdCounter++; // Müşteri ID'si, sayaçtan alınır

                    _users.Add(user);
                    _customers.Add(customer);
                }
                // Verilerin bir kere oluşturulduğunu işaretle
                _dataGenerated = true;
            }

            return _customers;
        }


        private static List<Branch> GenerateBranches()
        {
            var branchFaker = new Faker<Branch>("tr")
                .RuleFor(branch => branch.branch_name, f => f.PickRandom(
                    "Ziraat Bankası",
                    "Halkbank",
                    "VakıfBank",
                    "Garanti BBVA",
                    "İş Bankası",
                    "Yapı Kredi",
                    "Akbank",
                    "QNB Finansbank",
                    "DenizBank",
                    "TEB"))
                .RuleFor(branch => branch.location, f => $"{f.Address.StreetAddress()}, {f.Address.City()}, Türkiye")
                .RuleFor(branch => branch.phone_number, f => f.Phone.PhoneNumberFormat())
                .RuleFor(branch => branch.email, (f, branch) => $"{branch.branch_name.Replace(" ", "")}@gmail.com")
                .RuleFor(branch => branch.status, f => f.PickRandom("Active", "Inactive"));

            var branches = branchFaker.Generate(10); // 10 şube oluştur

            // ID'leri 1'den başlayacak şekilde ayarla
            int id = 1;
            foreach (var branch in branches)
            {
                branch.Id = id++;
            }

            return branches;
        }

        public static List<Branch> GetBranches()
        {
            if (!_dataGenerated)
            {


                _dataGenerated = true;
            }

            return _branches;
        }


        // Tohum değeri (seed) ayarla
        private const int BalanceSeed = 123;


        public static List<Currency> GetCurrencies()
        {
            return _currencies;
        }


        private static readonly Faker<Balance> _balanceFaker = new Faker<Balance>()
            .RuleFor(balance => balance.balance, f => (decimal)f.Finance.Amount(5000, 20000));

        private static readonly List<Currency> _currencies = new List<Currency>
    {
    new Currency { Id = 1, currency_name = "Euro", currency_symbol = "€" },
    new Currency { Id = 2, currency_name = "Dollar", currency_symbol = "$" },
    new Currency { Id = 3, currency_name = "Turkish Lira", currency_symbol = "₺" }
    };



        public static List<Balance> GetBalances()
        {

            if (!_dataGenerated)
            {
                _balances.Clear();
                var currencies = GetCurrencies().Take(50).ToList(); // Tüm mevcut para birimlerini al

                // Tohum değerini kullanarak rastgele veri oluştur
                Randomizer.Seed = new Random(BalanceSeed);

                int balanceId = 1;
                for (int i = 0; i < 50; i++)
                {
                    var balance = _balanceFaker.Generate();

                    // Her bir balance için CurrencyId değerini hesapla
                    balance.CurrencyId = currencies[i % currencies.Count].Id;
                    balance.Currency = currencies[i % currencies.Count];

                    balance.Id = balanceId++;
                    _balances.Add(balance);
                }

                // Verilerin bir kere oluşturulduğunu işaretle
                _dataGenerated = true;
            }

            return _balances;
        }



        private const int AccountSeed = 123;
        public static List<Account> GetAccounts()
        {
            if (!_dataGenerated)
            {
                _accounts.Clear();

                var customers = GetCustomers(); // Müşterileri al
                var balances = GetBalances(); // Bakiyeleri al
                var branches = GenerateBranches(); // Şubeleri al
                Randomizer.Seed = new Random(AccountSeed);



                int accountIdCounter = 1;

                for (int i = 0; i < 50; i++)
                {
                    var account = _accountFaker.Generate();
                    var balance = FakeDataBalance.GetBalances()[i]; // Her bir hesap için bir denge al

                    account.CustomerId = customers[i].Id;
                    account.Customer = customers[i];

                    account.BalanceId = balance.Id;
                    account.Balance = balance;

                    var branch = branches[random.Next(branches.Count)];
                    account.BranchId = branch.Id;
                    account.Branch = branch;


                    account.Id = accountIdCounter++;

                    _accounts.Add(account);
                }


                _dataGenerated = true;
            }

            return _accounts;
        }
        public static void SaveAccountsToDatabase()
        {
            using (var context = new AccountDbContext())
            {
                if (!context.Accounts.Any())
                {
                    var accounts = GetAccounts(); // Hesapları al
                    foreach (var account in accounts)
                    {
                        context.Accounts.Add(account);
                    }
                    context.SaveChanges();
                }
            }

            using (var context = new AccountDbContext())
            {
                var accounts = GetAccounts(); // Hesapları al
                foreach (var account in accounts)
                {
                    if (!context.Accounts.Any(a => a.Id == account.Id))
                    {
                        // Müşteri ve kullanıcıyı da ekle
                        if (!context.Customers.Any(c => c.Id == account.Customer.Id))
                        {
                            context.Customers.Add(account.Customer);
                        }

                        if (!context.Users.Any(u => u.Id == account.Customer.User.Id))
                        {
                            context.Users.Add(account.Customer.User);
                        }

                        // Bakiye ve şubeyi de ekle
                        if (!context.Balances.Any(b => b.Id == account.Balance.Id))
                        {
                            context.Balances.Add(account.Balance);
                        }

                        if (!context.Branches.Any(b => b.Id == account.Branch.Id))
                        {
                            context.Branches.Add(account.Branch);
                        }

                        context.Accounts.Add(account);
                    }
                }
               // context.SaveChanges();
            }
        }
    }
}


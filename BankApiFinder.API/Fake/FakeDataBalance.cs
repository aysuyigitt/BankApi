using BankApi.DataAccess;
using BankApi.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApiFinder.API.Fake
{
    public class FakeDataBalance
    {

        // Tohum değeri (seed) ayarla
        private const int BalanceSeed = 123;

        private static readonly List<Balance> _balances = new List<Balance>();

        public static List<Currency> GetCurrencies()
        {
            return _currencies;
        }


        private static bool _dataGenerated = false;

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

                // Veritabanına kaydetme işlemi
                using (var context = new BalanceDbContext())
                {
                    // Veritabanında kullanıcılar var mı kontrol et
                    if (!context.Balances.Any())
                    {
                        foreach (var balance in _balances)
                        {
                            context.Balances.Add(balance);
                        }
                       // context.SaveChanges();
                    }
                }

                // Verilerin bir kere oluşturulduğunu işaretle
                _dataGenerated = true;
            }

            return _balances;
        }

    }
}
using BankApi.DataAccess;
using BankApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BankApiFinder.API.Fake
{
	public class FakeDataCurrency
	{
        private static bool _dataGenerated = false;

        public static List<Currency> GetCurrencies(int number)
        {
            if (!_dataGenerated)
            {
                using (var context = new CurrencyDbContext())
                {
                    // Currency tablosunda veri var mı kontrol et
                    if (!context.Currencies.Any())
                    {
                        // Currency verilerini ekle
                        int currencyId = 1;
                        foreach (var currency in _currencies)
                        {
                            currency.Id = currencyId++;
                            context.Currencies.Add(currency);
                        }
                        context.SaveChanges();
                    }
                }

                // Verilerin bir kere oluşturulduğunu işaretle
                _dataGenerated = true;
            }

            var result = new List<Currency>();
            for (int i = 0; i < number; i++)
            {
                result.Add(_currencies[i % _currencies.Count]);
            }

            return result;
        }

        private static readonly List<Currency> _currencies = new List<Currency>
        {
        new Currency { Id = 1, currency_name = "Euro", currency_symbol = "€" },
        new Currency { Id = 2, currency_name = "Dollar", currency_symbol = "$" },
        new Currency { Id = 3, currency_name = "Turkish Lira", currency_symbol = "₺" }
        };
    }
}
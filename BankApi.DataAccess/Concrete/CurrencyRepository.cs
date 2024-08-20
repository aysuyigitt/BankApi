using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public Currency CreateCurrency(Currency currency)
        {
            using (var currencyDbContext = new CurrencyDbContext())
            {
                currencyDbContext.Currencies.Add(currency);
                currencyDbContext.SaveChanges();
                return currency;
            }
        }

        public List<Currency> GetAllCurrencies()
        {
            using (var currencyDbContext = new CurrencyDbContext())
            {
                return currencyDbContext.Currencies.ToList();
            }
        }
    }
}

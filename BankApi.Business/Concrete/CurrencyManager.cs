using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyRepository _currencyRepository;

        public CurrencyManager()
        {
            _currencyRepository = new CurrencyRepository();
        }
        public Currency CreateCurrency(Currency currency)
        {
            return _currencyRepository.CreateCurrency(currency);
        }

        public List<Currency> GetAllCurrencies()
        {
            return _currencyRepository.GetAllCurrencies();
        }
    }
}

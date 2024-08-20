using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies();

        Currency CreateCurrency(Currency currency);
    }
}

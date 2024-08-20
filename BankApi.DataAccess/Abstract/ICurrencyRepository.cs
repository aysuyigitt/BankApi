using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAllCurrencies();

        Currency CreateCurrency(Currency currency);
    }
}

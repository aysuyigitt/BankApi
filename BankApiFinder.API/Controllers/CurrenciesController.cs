using BankApi.Business.Abstract;
using BankApi.Business.Concrete;
using BankApi.Entities;
using BankApiFinder.API.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private ICurrencyService _currencyService;

        public CurrenciesController()
        {
            _currencyService = new CurrencyManager();
        }
        private List<Currency> _currencies = FakeDataCurrency.GetCurrencies(3);

        [HttpGet]
        public List<Currency> Get()
        {
            return _currencies;
        }

        [HttpPost]
        public Currency Post([FromBody] Currency currency)
        {
            _currencies.Add(currency);
            return currency;
        }
    }
}
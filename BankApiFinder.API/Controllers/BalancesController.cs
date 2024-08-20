using BankApi.Business.Abstract;
using BankApi.Business.Concrete;
using BankApi.Entities;
using BankApiFinder.API.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private IBalanceService _balanceService;

        public BalancesController()
        {
            _balanceService = new BalanceManager();
        }
        private List<Balance> _balances = FakeDataBalance.GetBalances();

        [HttpGet]
        public List<Balance> Get()
        {
            return _balances;
        }

        [HttpGet("{id}")]
        public Balance Get(int id)
        {
            var balance = _balances.FirstOrDefault(x => x.Id == id);
            return balance;
        }

        [HttpPost]
        public Balance Post([FromBody] Balance balance)
        {
            _balances.Add(balance);
            return balance;
        }

        [HttpPut]
        public Balance Put([FromBody] Balance balance)
        {
            var editedBalance = _balances.FirstOrDefault(x => x.Id == balance.Id);
            editedBalance.balance = balance.balance;
            return balance;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteBalance = _balances.FirstOrDefault(x => x.Id == id);
            _balances.Remove(deleteBalance);
        }
    }
}
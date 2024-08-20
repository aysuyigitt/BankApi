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
    public class AccountsController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountsController()
        {
            _accountService = new AccountManager();
        }
        private List<Account> _accounts = FakeDataAccount.GetAccounts();

        [HttpGet]
        public List<Account> Get()
        {
            return _accounts;
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            var account = _accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        [HttpPost]
        public Account Post([FromBody] Account account)
        {
            _accounts.Add(account);
            return account;
        }

        [HttpPut]
        public Account Put([FromBody] Account account)
        {
            var editedAccount = _accounts.FirstOrDefault(x => x.Id == account.Id);
            editedAccount.account_number = account.account_number;
            editedAccount.open_date = account.open_date;

            return account;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteAccount = _accounts.FirstOrDefault(x => x.Id == id);
            _accounts.Remove(deleteAccount);
        }
    }
}


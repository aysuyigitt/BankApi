using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountManager()
        {
            _accountRepository = new AccountRepository();
        }
        public Account CreateAccount(Account account)
        {
            return _accountRepository.CreateAccount(account);
        }

        public void DeleteAccount(int id)
        {
            _accountRepository.DeleteAccount(id);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public Account GetAccountById(int id)
        {
            return _accountRepository.GetAccountById(id);
        }

        public Account UpdateAccount(Account account)
        {

            return _accountRepository.UpdateAccount(account);
        }

        Account IAccountService.DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetByaccount_number(int account_number)
        {
           return _accountRepository.GetByIdaccount_number(account_number); 
        }
    }
}
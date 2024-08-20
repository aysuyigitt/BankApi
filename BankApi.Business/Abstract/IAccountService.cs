using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();

        Account GetAccountById(int id);

        Account CreateAccount(Account account);

        Account UpdateAccount(Account account);

        Account DeleteAccount(int id);

        Account GetByaccount_number(int account_number);


    }
}

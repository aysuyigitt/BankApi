using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccounts();

        Account GetAccountById(int id);

        Account CreateAccount(Account account);

        Account UpdateAccount(Account account);

        Account DeleteAccount(int id);

        Account GetByIdaccount_number(int account_number);
     
    }
}

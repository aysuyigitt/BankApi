using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        public Account CreateAccount(Account account)
        {
            using (var accountDbContext = new AccountDbContext())
            {
                accountDbContext.Accounts.Add(account);
                accountDbContext.SaveChanges();
                return account;
            }
        }
        public void DeleteAccount(int id)
        {
            using (var accountDbContext = new AccountDbContext())
            {
                var deleteAccount = GetAccountById(id);
                accountDbContext.Accounts.Remove(deleteAccount);
                accountDbContext.SaveChanges();
            }
        }

        public Account GetAccountById(int id)
        {
            using (var accountDbContext = new AccountDbContext())
            {
                return accountDbContext.Accounts.Find(id);
            }
        }


        public List<Account> GetAllAccounts()
        {
            using (var accountDbContext = new AccountDbContext())
            {
                return accountDbContext.Accounts.ToList();
            }
        }

        public Account GetByIdaccount_number(int account_number)
        {
            using (var accountDbContext = new AccountDbContext())
            {
                return accountDbContext.Accounts.Find(account_number);
            }
        }

        public Account UpdateAccount(Account account)
        {
            using (var accountDbContext = new AccountDbContext())
            {
                accountDbContext.Accounts.Update(account);
                return account;
            }
        }

     

        Account IAccountRepository.DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}


        
   
        
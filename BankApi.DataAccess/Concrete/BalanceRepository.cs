using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class BalanceRepository : IBalanceRepository
    {

        public Balance CreateBalance(Balance balance)
        {
            using (var balanceDbContext = new BalanceDbContext())
            {
                balanceDbContext.Balances.Add(balance);
                balanceDbContext.SaveChanges();
                return balance;
            }
        }
        public List<Balance> GetAllBalances()
        {
            using (var balanceDbContext = new BalanceDbContext())
            {
                return balanceDbContext.Balances.ToList();
            }
        }

        public Balance GetBalanceById(int id)
        {
            using (var balanceDbContext = new BalanceDbContext())
            {
                return balanceDbContext.Balances.Find(id);
            }
        }

        public Balance UpdateBalance(Balance balance)
        {
            using (var balanceDbContext = new BalanceDbContext())
            {
                balanceDbContext.Balances.Update(balance);
                return balance;
            }
        }
    }
}
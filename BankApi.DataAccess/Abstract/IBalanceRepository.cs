using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
    public interface IBalanceRepository
    {
        List<Balance> GetAllBalances();

        Balance GetBalanceById(int id);

        Balance CreateBalance(Balance balance);

        Balance UpdateBalance(Balance balance);

    }
}

using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
    public interface IBalanceService
    {
        List<Balance> GetAllBalances();

        Balance GetBalanceById(int id);
        Balance CreateBalance(Balance balance);

        Balance UpdateBalance(Balance balance);
    }
}

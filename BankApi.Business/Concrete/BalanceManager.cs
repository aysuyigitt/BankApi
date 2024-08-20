using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class BalanceManager : IBalanceService
    {
      
            private IBalanceRepository _balanceRepository;

            public BalanceManager()
            {
                _balanceRepository = new BalanceRepository();
            }

            public Balance CreateBalance(Balance balance)
            {
                return _balanceRepository.CreateBalance(balance);
            }

            public List<Balance> GetAllBalances()
            {
                return _balanceRepository.GetAllBalances();
            }

            public Balance GetBalanceById(int id)
            {
                return _balanceRepository.GetBalanceById(id);
            }

            public Balance UpdateBalance(Balance balance)
            {
                return _balanceRepository.UpdateBalance(balance);
            }
        }
    }
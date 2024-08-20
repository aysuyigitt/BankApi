using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
	public interface ITransactionRepository
	{
		List<Transaction> GetAllTransactions();

		Transaction CreateTransaction(Transaction transaction);	
	}
}

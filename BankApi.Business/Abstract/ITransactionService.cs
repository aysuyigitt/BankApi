using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
	public interface ITransactionService
	{
		List<Transaction> GetAllTransactions();

		//Transaction GetByIdTransaction(int id);	
		Transaction CreateTransaction(Transaction transaction);
	}
}

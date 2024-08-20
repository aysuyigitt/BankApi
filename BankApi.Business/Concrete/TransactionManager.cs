using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BankApi.Business.Concrete
{
	public class TransactionManager : ITransactionService 
	{ 
		private ITransactionRepository _transactionRepository;

		public TransactionManager()
		{
			_transactionRepository = new TransactionRepository();
		}

		public Entities.Transaction CreateTransaction(Entities.Transaction transaction)
		{
			return _transactionRepository.CreateTransaction(transaction);	
		}

		public List<Entities.Transaction> GetAllTransactions()
		{
			return _transactionRepository.GetAllTransactions();
		}
	}
}

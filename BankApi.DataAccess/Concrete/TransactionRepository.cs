using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
	public class TransactionRepository : ITransactionRepository
	{
		public Transaction CreateTransaction(Transaction transaction)
		{
			using (var transactionDbContext = new TransactionDbContext())
			{
				transactionDbContext.Transactions.Add(transaction);
				transactionDbContext.SaveChanges();
				return transaction;
			}
		}

		public List<Transaction> GetAllTransactions()
		{
			using (var transactionDbContext = new TransactionDbContext())
			{
				return transactionDbContext.Transactions.ToList();
			}
		}
		//public Transaction GetByIdTransaction(int id)
		//{
		//	using (var transactionDbContext = new TransactionDbContext())
		//	{
		//		return transactionDbContext.Transactions.Find(id);
				
		//	}
		}
	}



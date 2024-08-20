using BankApi.Business.Abstract;
using BankApi.Entities;
using BankApiFinder.API.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using BankApi.Business.Concrete;

namespace BankApiFinder.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private ITransactionService _transactionService;

		public TransactionsController()
		{
			_transactionService = new TransactionManager();
		}

		private static List<Account> _accounts = FakeDataAccount.GetAccounts();
		private static List<Transaction> _transactions = new List<Transaction>();


		[HttpGet]
		public List<Transaction> Get()
		{
			return _transactions;
		}


		[HttpPost]
		public IActionResult Post([FromBody] Transaction transaction)
		{
			var senderAccount = _accounts.FirstOrDefault(x => x.account_number == transaction.SenderAccountNumber);
			var receiverAccount = _accounts.FirstOrDefault(x => x.account_number == transaction.ReceiverAccountNumber);

			if (senderAccount == null || receiverAccount == null)
			{
				return BadRequest("Sender or Receiver account not found.");
			}

			if (senderAccount.Balance.balance < transaction.Amount)
			{
				return BadRequest("Insufficient funds in sender's account.");
			}

			// Perform the transfer
			senderAccount.Balance.balance -= transaction.Amount;
			receiverAccount.Balance.balance += transaction.Amount;

			// Set the transaction details
			transaction.Id = _transactions.Count + 1; // Simulate auto-incrementing ID
			transaction.TransactionDate = DateTime.Now;
			transaction.SenderAccount = senderAccount;
			transaction.ReceiverAccount = receiverAccount;

			_transactions.Add(transaction);

			//var createdTransaction = _transactionService.CreateTransaction(transaction);

			return Ok(transaction);
			
		}




	}
}
	

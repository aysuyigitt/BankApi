using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApi.Entities
{
	public class Transaction
	{
        public int Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string TransactionDescription { get; set; }
		public int SenderAccountNumber { get; set; }
		public int ReceiverAccountNumber { get; set; }

		[ForeignKey("SenderAccountNumber")]
		public Account SenderAccount { get; set; }

		[ForeignKey("ReceiverAccountNumber")]
		public Account ReceiverAccount { get; set; }

	}
}

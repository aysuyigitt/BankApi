using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DtoLayer.TransactionDtos
{
	public class TransactionDto
	{
		

		public decimal Amount { get; set; }

		public string TransactionType { get; set; }

		public DateTime TransactionDate { get; set; }

		public string TransactionDescription { get; set; }

		public int? SenderId { get; set; }

		public int? ReceiverId { get; set; }

		public int ReceiverAccountNumber { get; set; }

	}
}

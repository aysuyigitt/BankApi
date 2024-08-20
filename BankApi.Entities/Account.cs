using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApi.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public int account_number {  get; set; }

        public DateTime open_date { get; set; }

        public int? CustomerId { get; set; }

        public int? BranchId { get; set; }

        public int? BalanceId { get; set; }

		

		[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }


        [ForeignKey("BalanceId")]
        public Balance Balance { get; set; }

		
	}
}

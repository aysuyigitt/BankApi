using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApi.Entities
{
    public class Balance
    {
        public int Id { get; set; }

        public decimal? balance { get; set; }

        public int? CurrencyId { get; set; }

     

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

    }
}

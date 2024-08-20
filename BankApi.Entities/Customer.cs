using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankApi.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string customer_email { get; set; }

        public string phone_number { get; set; }

        public string address { get; set; }

        public DateTime date_of_birth { get; set; }



        [ForeignKey("UserId")]
        
        public User User { get; set; }
    }
}

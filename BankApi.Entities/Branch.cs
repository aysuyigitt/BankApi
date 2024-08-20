using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        public string branch_name { get; set; }

        public string location { get; set; }

        public string phone_number { get; set; }

        public string email { get; set; }

        public string status { get; set; }

       
    }
}

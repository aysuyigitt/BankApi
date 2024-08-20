using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Entities
{
    public class Response
    {
        public string RequestId => $"{Guid.NewGuid().ToString()}";

        public string ResponseCode { get; set; }

        public string ResponseMessage {  get; set; }    

        public object ResponseData { get; set; }    

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentGateWay.Models
{
    public class PaymentModel
    {
        public string AccName {get;set;}
        public double Account { get; set; }
        public int Amount { get; set; }
        public string ReceiptNum { get; set; }
    }
}
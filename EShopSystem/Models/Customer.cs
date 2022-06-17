using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public float CustomerBalance { get; set; }
    }
}
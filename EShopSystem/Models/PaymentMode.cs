using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopSystem.Models
{
    public class PaymentMode
    {
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
        public bool PaymentModeIsActive { get; set; }
    }
}
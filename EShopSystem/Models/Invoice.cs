using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopSystem.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceData { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal InvoiceTotal { get; set; }
        public bool IsPaid { get; set; }
        public int PaymentModeId { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new HashSet<InvoiceDetail>();

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public PaymentMode PaymentMode { get; set; }

    }
}
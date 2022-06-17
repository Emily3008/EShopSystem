namespace EShopSystem.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

    }
}
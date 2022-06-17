namespace EShopSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float ProductStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
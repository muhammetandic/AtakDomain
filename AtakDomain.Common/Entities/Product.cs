namespace AtakDomain.Common.Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string productId)
        {
            ProductId = productId;
        }

        public Product(string productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }

        public Product(string productId, string productName, string categoryId)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<History> Histories { get; }
        public ICollection<OrderItem> OrderItems { get; }
    }
}
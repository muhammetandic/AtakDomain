namespace AtakDomain.Common.Entities
{
    public class OrderItem
    {
        public OrderItem(int orderId, string productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
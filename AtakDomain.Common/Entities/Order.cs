namespace AtakDomain.Common.Entities
{
    public class Order
    {
        public Order(string userId)
        {
            UserId = userId;
        }

        public Order(int orderId, string userId)
        {
            OrderId = orderId;
            UserId = userId;
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
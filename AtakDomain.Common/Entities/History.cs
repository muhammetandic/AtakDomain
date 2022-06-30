namespace AtakDomain.Common.Entities
{
    public class History
    {
        public History(string userId, string productId, DateTime timeStamp)
        {
            UserId = userId;
            ProductId = productId;
            TimeStamp = timeStamp;
        }

        public int HistoryId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
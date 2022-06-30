namespace AtakDomain.Common.Entities
{
    public class User
    {
        public User(string userId)
        {
            UserId = userId;
        }

        public User(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
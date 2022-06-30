namespace AtakDomain.Common.Entities
{
    public class Category
    {
        public Category()
        {
        }

        public Category(string categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
using AtakDomain.Common.Entities;
using AtakDomain.DataDump;

var random = new Random();

List<Category> categories = new();
for (int i = 0; i < 100; i++)
{
    categories.Add(new Category("category-" + i.ToString(), "category-" + i.ToString()));
}

string insertSql = "INSERT INTO \"Categories\" (\"CategoryId\", \"CategoryName\") VALUES (@CategoryId, @CategoryName)";
WriteToDb.WriteToTable(insertSql, categories);
Console.WriteLine("Categories created");

List<User> users = new();
for (int i = 0; i < 1000; i++)
{
    users.Add(new User("user-" + i.ToString(), "user-" + i.ToString()));
}

insertSql = "INSERT INTO \"Users\" (\"UserId\", \"UserName\") VALUES (@UserId, @UserName)";
WriteToDb.WriteToTable(insertSql, users);
Console.WriteLine("Users created");

List<Product> products = new();
for (int i = 0; i < 1000; i++)
{
    products.Add(new Product("product-" + i.ToString(), "product-" + i.ToString(), "category-" + random.Next(1, 99).ToString()));
}

insertSql = "INSERT INTO \"Products\" (\"ProductId\", \"ProductName\", \"CategoryId\") VALUES (@ProductId, @ProductName, @CategoryId)";
WriteToDb.WriteToTable(insertSql, products);
Console.WriteLine("Products created");

List<Order> orders = new();
List<OrderItem> orderItems = new();
for (int i = 1; i <= 100000; i++)
{
    orders.Add(new Order(i, "user-" + random.Next(1, 999).ToString()));
    var orderItemCount = random.Next(1, 3);
    for (int j = 0; j < orderItemCount; j++)
    {
        orderItems.Add(new OrderItem(i, "product-" + random.Next(1, 999).ToString(), random.Next(1, 10)));
    }
}

insertSql = "INSERT INTO \"Orders\" (\"OrderId\", \"UserId\") VALUES (@OrderId, @UserId)";
WriteToDb.WriteToTable(insertSql, orders);
Console.WriteLine("Orders created");

insertSql = "INSERT INTO \"OrderItems\" (\"OrderId\", \"ProductId\", \"Quantity\") VALUES (@OrderId, @ProductId, @Quantity)";
WriteToDb.WriteToTable(insertSql, orderItems);
Console.WriteLine("OrderItems created");
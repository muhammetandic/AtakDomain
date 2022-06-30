using AtakDomain.Common.Entities;
using Dapper;
using Npgsql;

namespace AtakDomain.StreamReader
{
    public static class DbWriter
    {
        public static void WriteHistory(History history)
        {
            const string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123456;";
            const string insertSql = "INSERT INTO \"Histories\" (\"UserId\", \"ProductId\", \"TimeStamp\") VALUES (@UserId, @ProductId, @TimeStamp);";
            using var connection = new NpgsqlConnection(connectionString);
            connection.Execute(insertSql, history);
        }

        public static void WriteUser(User user)
        {
            const string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123456;";
            const string insertSql = "INSERT INTO \"Users\" (\"UserId\") VALUES (@UserId);";
            const string selectSql = "SELECT * FROM \"Users\" WHERE \"UserId\" = @UserId;";

            using var connection = new NpgsqlConnection(connectionString);
            var isExist = connection.QueryFirstOrDefault<User>(selectSql, user);
            if (isExist == null)
            {
                connection.Execute(insertSql, user);
            }
        }

        public static void WriteProduct(Product product)
        {
            const string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123456;";
            const string insertSql = "INSERT INTO \"Products\" (\"ProductId\") VALUES(@ProductId);";
            const string selectSql = "SELECT * FROM \"Products\" WHERE \"ProductId\" = @ProductId;";

            using var connection = new NpgsqlConnection(connectionString);
            var isExist = connection.QueryFirstOrDefault<Product>(selectSql, new { product.ProductId });
            if (isExist == null)
            {
                connection.Execute(insertSql, product);
            }
        }
    }
}
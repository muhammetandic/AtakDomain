using Dapper;
using Npgsql;

namespace AtakDomain.DataDump
{
    public static class WriteToDb
    {
        private const string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123456;";

        public static void WriteToTable(string insertSql, object data)
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Execute(insertSql, data);
        }
    }
}
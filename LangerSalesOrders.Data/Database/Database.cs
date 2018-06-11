using System.Data.Common;

namespace LangerSalesOrders.Data.Database
{
    public class Database
    {
        public Database(string connectionString, DbProviderFactory factory)
        {
            ConnectionString = connectionString;
            Factory = factory;
        }

        public string ConnectionString { get; protected set; }
        public DbProviderFactory Factory { get; protected set; }

        public DbConnection CreateConnection()
        {
            var conn = Factory.CreateConnection();
            conn.ConnectionString = ConnectionString;

            return conn;
        }

        public DbScope Begin()
        {
            var conn = CreateConnection();
            conn.Open();
            return new DbScope(conn);
        }
    }
}

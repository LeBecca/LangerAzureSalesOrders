using System;
using System.Data;

namespace LangerSalesOrders.Data.Database
{
    public class DbScope : IDisposable
    {
        public DbScope(IDbConnection connection)
        {
            Connection = connection;
            CommandTimeout = 100000;
        }

        public IDbConnection Connection { get; protected set; }
        public int CommandTimeout { get; set; }

        public void Dispose()
        {
            this.Connection?.Dispose();
        }
    }
}

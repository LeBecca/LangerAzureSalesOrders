using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using LangerSalesOrders.Data.Database;
using LangerSalesOrders.Data.DataModels;

namespace LangerSalesOrders.Data.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        protected DbScope DbScope { get; set; }

        public SalesOrderRepository(DbScope dbScope)
        {
            DbScope = dbScope;
        }

        public async Task<IEnumerable<SalesOrderDataModel>> GetSalesOrdersAsync()
        {
            var query = $"{SqlTextResourceHelper.GetTextResource("GetSalesOrderList")}";

            return await DbScope.Connection.QueryAsync<SalesOrderDataModel>(query);
        }

        public async Task<IEnumerable<SalesOrderDataModel>> GetSalesOrdersPagedAsync(int pageNumber, int pageSize)
        {
            var query = $@"
SELECT * FROM (
{SqlTextResourceHelper.GetTextResource("GetSalesOrderList")}
) X WHERE X.[RowNum] BETWEEN @FirstRowNum AND @LastRowNum";

            return await DbScope.Connection.QueryAsync<SalesOrderDataModel>(query,
                param: new
                {
                    FirstRowNum = ((pageNumber - 1) * pageSize) + 1,
                    LastRowNum = (pageNumber * pageSize)
                });
        }
    }
}

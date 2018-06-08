using LangerSalesOrders.Data.DataModels;
using System.Collections.Generic;

namespace LangerSalesOrders.Data.Repositories
{
    public interface ISalesOrderRepository
    {
        IEnumerable<SalesOrderDataModel> GetSalesOrdersAsync();

        IEnumerable<SalesOrderDataModel> GetSalesOrdersPagedAsync(int pageNumber, int pageSize);
    }
}

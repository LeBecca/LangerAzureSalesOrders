using LangerSalesOrders.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LangerSalesOrders.Data.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<SalesOrderDataModel>> GetSalesOrdersAsync();

        Task<IEnumerable<SalesOrderDataModel>> GetSalesOrdersPagedAsync(int pageNumber, int pageSize);
    }
}

using System.Collections.Generic;

namespace LangerSalesOrdersWebsite.Models.SalesOrder
{
    public class SalesOrderListModel
    {
        public IEnumerable<SalesOrderListItemModel> Items { get; set; }
    }
}

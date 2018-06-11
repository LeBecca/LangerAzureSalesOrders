using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangerSalesOrdersWebsite.Models.SalesOrder
{
    public class SalesOrderListItemModel
    {
        public string SalesOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal TotalAmountDue { get; set; }
        public string SalesPersonName { get; set; }
    }
}

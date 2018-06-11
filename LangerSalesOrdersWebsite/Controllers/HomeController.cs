using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LangerSalesOrdersWebsite.Models;
using LangerSalesOrdersWebsite.Models.SalesOrder;
using LangerSalesOrders.Data.Repositories;
using System.Linq;

namespace LangerSalesOrdersWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalesOrderRepository _repository;

        // TODO: get this from a configuration or let the user select page size
        private const int PAGE_SIZE = 20;

        public HomeController(ISalesOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var model = new SalesOrderListModel
            {
                Items = (await _repository.GetSalesOrdersPagedAsync(1, PAGE_SIZE))
                    .Select(s => new SalesOrderListItemModel
                    {
                        SalesOrderNumber = s.SalesOrderNumber,
                        DueDate = s.DueDate,
                        ShipDate = s.ShipDate,
                        OrderDate = s.OrderDate,
                        Status = s.Status,
                        PurchaseOrderNumber = s.PurchaseOrderNumber,
                        AccountNumber = s.AccountNumber,
                        SubtotalAmount = s.SubtotalAmount,
                        TaxAmount = s.TaxAmount,
                        FreightAmount = s.FreightAmount,
                        TotalAmountDue = s.TotalAmountDue,
                        SalesPersonName = string.Join(", ", s.SalesPersonLastName ?? string.Empty, s.SalesPersonFirstName ?? string.Empty)
                    })
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListPage(int pageNumber)
        {
            if (pageNumber <= 0)
            {
                return BadRequest();
            }

            var model = new SalesOrderListModel
            {
                //Items = (await _repository.GetSalesOrdersPagedAsync(pageNumber, PAGE_SIZE))
                //    .Select(s => new SalesOrderListItemModel
                //    {
                //        SalesOrderNumber = s.SalesOrderNumber,
                //        DueDate = s.DueDate,
                //        ShipDate = s.ShipDate,
                //        OrderDate = s.OrderDate,
                //        Status = s.Status,
                //        PurchaseOrderNumber = s.PurchaseOrderNumber,
                //        AccountNumber = s.AccountNumber,
                //        SubtotalAmount = s.SubtotalAmount,
                //        TaxAmount = s.TaxAmount,
                //        FreightAmount = s.FreightAmount,
                //        TotalAmountDue = s.TotalAmountDue,
                //        SalesPersonName = string.Join(", ", s.SalesPersonLastName ?? string.Empty, s.SalesPersonFirstName ?? string.Empty)
                //    })
            };

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

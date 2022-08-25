using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;
using ASM_App_Dev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

namespace ASM_App_Dev.Controllers
{
    [Authorize(Roles = Role.STORE_OWNER)]
    public class RecordsController : Controller
    {
        // 1 - Declare ApplicationDbContext
        private ApplicationDbContext _context;
        public RecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders  = _context.Orders
                .Include(t=>t.User)
                .ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            CheckOut checkOut = new CheckOut();

             var ordersDetails = _context.OrderDetails
            .Include(t => t.Order).Include( t => t.Order.User).Include(t => t.Book)
            .Where(t => t.OrderId == id).ToList();


			      checkOut.orderDetails = ordersDetails;
            checkOut.Name = ordersDetails[0].Order.User.FullName;
            checkOut.Address = ordersDetails[0].Order.User.Address;
            checkOut.TotalPrice = ordersDetails[0].Order.PriceOrder;

            return View(checkOut);
        }
    }
}

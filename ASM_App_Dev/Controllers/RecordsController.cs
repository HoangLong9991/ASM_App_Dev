using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;

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

        public IActionResult Details()
        {
            return View();
        }
    }
}

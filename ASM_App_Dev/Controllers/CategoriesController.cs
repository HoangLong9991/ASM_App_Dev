using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace ASM_App_Dev.Controllers
{
    [Authorize(Roles = Role.STORE_OWNER)]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        
    }
}

using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM_App_Dev.Controllers
{
    [Authorize(Roles = Role.STORE_OWNER)]
    public class CategoriesController : Controller
    {
        // 1 - Declare ApplicationDbContext
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


        // 2 - Create Category Data
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var newCategory = new Category
            {
                NameCategory = category.NameCategory,
                Status = Enums.CategoryStatus.InProgess
            };

            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

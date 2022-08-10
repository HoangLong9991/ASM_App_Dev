using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ASM_App_Dev.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            
            var userWithPermission = _userManager.GetUsersInRoleAsync(Role.CUSTOMER).Result;
            return View(userWithPermission);
        }

        

         

    }
}

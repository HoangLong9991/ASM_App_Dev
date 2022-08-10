using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;
using ASM_App_Dev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static ASM_App_Dev.Areas.Identity.Pages.Account.LoginModel;

namespace ASM_App_Dev.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SelectList RoleSelectList { get; set; }
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        [HttpGet]
        public IActionResult Index()
        {

            //List<SelectListItem> roleSelect = new List<SelectListItem>();

            //roleSelect.Add(new SelectListItem
            //{
            //    Text = "RoleAdmin",
            //    Value = Role.ADMIN
            //});
            //roleSelect.Add(new SelectListItem
            //{
            //    Text = "RoleStoreOwner",
            //    Value = Role.STORE_OWNER
            //});
            //roleSelect.Add(new SelectListItem
            //{
            //    Text = "RoleCustomer",
            //    Value = Role.CUSTOMER
            //});
            //ViewBag.RoleSelectList = roleSelect.ToList();
            //var userWithPermission = _userManager.GetUsersInRoleAsync(Role.CUSTOMER).Result;

            var roleList = _context.Roles.ToList();

            ViewData["RoleList"] = roleList;

            RoleSelectList = new SelectList(new List<string>
          {
            Role.ADMIN,
            Role.STORE_OWNER,
            Role.CUSTOMER
          }
      );

            var adminUser = new AdminViewModel()
            {
                UserWithPermission = _userManager.GetUsersInRoleAsync(Role.CUSTOMER).Result
            };

            adminUser.RoleSelectList = RoleSelectList; 


            return View(adminUser);
        }

        [HttpPost]
        public IActionResult Index(AdminViewModel adminViewModel)
        {
            var adminUser = new AdminViewModel();

            RoleSelectList = new SelectList(new List<string>
          {
            Role.ADMIN,
            Role.STORE_OWNER,
            Role.CUSTOMER
          }
      );
            var roleSelected = adminViewModel.Input.Role; 

            if(roleSelected == Role.STORE_OWNER)
            {
                adminUser = new AdminViewModel()
                {
                    UserWithPermission = _userManager.GetUsersInRoleAsync(Role.STORE_OWNER).Result
                };
            }
            else if(roleSelected == Role.CUSTOMER)
            {
                adminUser = new AdminViewModel()
                {
                    UserWithPermission = _userManager.GetUsersInRoleAsync(Role.CUSTOMER).Result
                };
            }
            else
            {
                adminUser = new AdminViewModel()
                {
                    UserWithPermission = _userManager.GetUsersInRoleAsync(Role.ADMIN).Result
                };
            }

            adminUser.RoleSelectList = RoleSelectList;

            return View(adminUser);


            //var roleList = _context.Roles.ToList();
            //ViewData["RoleList"] = roleList;

            //var idRole = "0d3151ac-ebae-47d5-8bd1-ac783afafee2";

        }





    }
}

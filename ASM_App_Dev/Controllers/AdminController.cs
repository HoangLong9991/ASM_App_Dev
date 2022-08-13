using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;
using ASM_App_Dev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using static ASM_App_Dev.Areas.Identity.Pages.Account.LoginModel;

namespace ASM_App_Dev.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SelectList RoleSelectList { get; set; } = new SelectList(new List<string>
          {
            "All User",
            Role.STORE_OWNER,
            Role.CUSTOMER
          }
      );
        public AdminController(ApplicationDbContext context, 
                                UserManager<ApplicationUser> userManager, 
                                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

            

        [HttpGet]
        public async Task<IActionResult> Index()
        {


            var model = new AdminViewModel();

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, Role.ADMIN))
                {
                    model.Users.Add(user);
                }
            }

            model.RoleSelectList = RoleSelectList; 


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(AdminViewModel adminViewModel)
        {
            var adminUser = new AdminViewModel();
            

            var roleSelectedInView = adminViewModel.Input.Role; 

            if(roleSelectedInView == Role.STORE_OWNER)
            {
                //adminUser = new AdminViewModel()
                //{
                //    UserWithPermission = _userManager.GetUsersInRoleAsync(Role.STORE_OWNER).Result
                //};

                adminUser = getUserByRole(Role.STORE_OWNER); 
            }
            else if(roleSelectedInView == Role.CUSTOMER)
            {
                adminUser = getUserByRole(Role.CUSTOMER);
            }
            else
            {
                adminUser = new AdminViewModel();

                foreach (var user in _userManager.Users)
                {
                    if (!await _userManager.IsInRoleAsync(user, Role.ADMIN))
                    {
                        adminUser.Users.Add(user);
                    }
                }
            }

            adminUser.RoleSelectList = RoleSelectList;
            return View(adminUser);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string id, [Bind("PasswordHash")] ApplicationUser user)
        {
            var getUser = _context.Users.SingleOrDefault(t => t.Id == id);
            var newPassword = user.PasswordHash; 

            if (getUser == null)
            {
                return BadRequest();
            }

            getUser.PasswordHash = _userManager.PasswordHasher.HashPassword(getUser, newPassword);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }



       


        [NonAction]
        private AdminViewModel getUserByRole(string role)
        {
            var adminUser = new AdminViewModel()
            {
                Users = (List<ApplicationUser>)_userManager.GetUsersInRoleAsync(role).Result
            };
            return adminUser;
        }



    }
}

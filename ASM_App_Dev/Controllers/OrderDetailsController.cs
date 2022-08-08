using ASM_App_Dev.Data;
using ASM_App_Dev.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ASM_App_Dev.Controllers
{
	[Authorize]
	public class OrderDetailsController : Controller
	{
		private ApplicationDbContext context;
		private readonly UserManager<ApplicationUser> userManager;

		public OrderDetailsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		public IActionResult Index(int id)
		{
			if (id != 0)
			{
				IEnumerable<OrderDetail> orderDetailByIdOrder = context.OrderDetails
					.Include(t => t.Book).Where(t => t.OrderId == id).ToList();
				return View(orderDetailByIdOrder);
			}
			IEnumerable<OrderDetail> orderDetailUncomfirm = context.OrderDetails.Include(t => t.Book)
				.Where(t => t.Order.StatusOrder == Enums.OrderStatus.Unconfirmed 
				&& t.Order.UserId == userManager.GetUserId(User)).ToList();

			return View(orderDetailUncomfirm);
		}
	}
}

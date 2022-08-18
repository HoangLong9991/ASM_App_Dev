using ASM_App_Dev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASM_App_Dev.ViewModels
{
	public class Cart
	{

		[BindProperty]
		public List<OrderDetail> orderDetails { get; set; }
		public int totalPrice { get; set; }
		
	}
}

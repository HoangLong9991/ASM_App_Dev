using ASM_App_Dev.Models;
using System.Collections.Generic;

namespace ASM_App_Dev.ViewModels
{
	public class CheckOut
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public List<OrderDetail> orderDetails { get; set; }
		public int TotalPrice { get; set; }

	}
}

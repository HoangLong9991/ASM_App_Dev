using ASM_App_Dev.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_App_Dev.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public DateTime DateOrder { get; set; } = DateTime.Now;
		public int PriceOrder { get; set; }
		public OrderStatus StatusOrder { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}

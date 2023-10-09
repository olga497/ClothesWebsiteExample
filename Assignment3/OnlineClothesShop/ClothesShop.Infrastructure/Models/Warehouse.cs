using System;
namespace ClothesShop.Infrastructure.Models
{
	public class WarehouseStock
	{
		public string ProductId { get; set; }
		//public string OrderId { get; set; } I need to change status of the order after the product quantity 
		public int? ProductQuantity { get; set; } // where do I specify product quantity
		// if I want to use it for the Warehouse database?
	}
}


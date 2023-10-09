using System;

namespace ClothesShop.Infrastructure.Models
{
	public class Order
	{
        public string? Id { get; set; }
        public string? Date { get; set; }
        //public static List<Product>? ProductsInOrder { get; set; }
        // public string? ProductId { get; set; } // should be list of products selected and their quantities
        public string? UserId { get; set; }
        public OrderStatus? Status { get; set; } 
        public double OrderSum { get; set; } // should be a calculated field
        // need to add list of Orders

    }
}


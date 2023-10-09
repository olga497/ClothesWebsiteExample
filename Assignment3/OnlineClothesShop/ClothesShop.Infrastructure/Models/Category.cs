using System;
namespace ClothesShop.Models
{
	public class Category
	{
            public string? Id { get; set; }
			public string? GlobalCategory { get; set; } // clothes, shoes
			public string? SpecificCategory { get; set; } // trousers, jackets etc.
			public string? SubCategory { get; set; } // trousers: jeans, classic
			public string? TargetAudience { get; set; } // men, women, children

	}
}


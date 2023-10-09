using System;
using ClothesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop
{
    public class DataSeeder
    {
        public static void SeedClothes(ProductDBContext context)
        {

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                    {
                        // Women
                        new Category { Id = "categoryId1", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Trousers", SpecificCategory = "Jeans" },
                        new Category { Id = "categoryId2", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Trousers", SpecificCategory = "SimpleTrousers" },
                        new Category { Id = "categoryId3", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Suits", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId4", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Suits", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId5", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Dresses", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId6", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Dresses", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId7", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Dresses", SpecificCategory = "Summer" },
                        new Category { Id = "categoryId8", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Skirts", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId9", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Skirts", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId10", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Shirts", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId11", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Shirts", SpecificCategory = "T-shirts" },
                        new Category { Id = "categoryId12", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Shirts", SpecificCategory = "Sports" },
                        new Category { Id = "categoryId13", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Underwear", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId14", GlobalCategory = "Clothes", TargetAudience = "Women", SubCategory = "Underwear", SpecificCategory = "Sports" },

                        // Men
                        new Category { Id = "categoryId15", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Trousers", SpecificCategory = "Jeans" },
                        new Category { Id = "categoryId16", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Trousers", SpecificCategory = "SimpleTrousers" },
                        new Category { Id = "categoryId17", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Suits", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId18", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Suits", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId19", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Shirts", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId20", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Shirts", SpecificCategory = "T-shirts" },
                        new Category { Id = "categoryId21", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Shirts", SpecificCategory = "Sports" },
                        new Category { Id = "categoryId22", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Underwear", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId23", GlobalCategory = "Clothes", TargetAudience = "Men", SubCategory = "Underwear", SpecificCategory = "Sports" },

                        // Children
                        new Category { Id = "categoryId24", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Trousers", SpecificCategory = "Jeans" },
                        new Category { Id = "categoryId25", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Trousers", SpecificCategory = "SimpleTrousers" },
                        new Category { Id = "categoryId26", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Suits", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId27", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Suits", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId28", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Shirts", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId29", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Shirts", SpecificCategory = "T-shirts" },
                        new Category { Id = "categoryId30", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Shirts", SpecificCategory = "Sports" },
                        new Category { Id = "categoryId31", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Underwear", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId32", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Underwear", SpecificCategory = "Sports" },
                        new Category { Id = "categoryId33", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Skirts", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId34", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Skirts", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId35", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Dresses", SpecificCategory = "Classic" },
                        new Category { Id = "categoryId36", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Dresses", SpecificCategory = "Casual" },
                        new Category { Id = "categoryId37", GlobalCategory = "Clothes", TargetAudience = "Children", SubCategory = "Dresses", SpecificCategory = "Summer" }
                    };

                // Save the predefined categories to the database
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        
            if (!context.Products.Any()) // if there are no items in the database
            {
                var clothes = new List<Product>
                {
                    new Product 
                    {
                        Id = Guid.NewGuid().ToString(),//unique identifier
                        Title = "Product 1", //
                        Size = "S",
                        Material = "Cotton 100",
                        Description = "A new t-shirt Female",
                        Brand = "New",
                        Price = 12.53,
                        CategoryId = "categoryId11",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Women"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Product 2", //
                        Size = "M",
                        Material = "Cotton 80",
                        Description = "A new t-shirt Female, made of cotton",
                        Brand = "New",
                        Price = 12.23,
                        CategoryId = "categoryId11",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Women"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Product 3", //
                        Size = "L",
                        Material = "Cotton 50",
                        Description = "A new t-shirt Male",
                        Brand = "Old",
                        Price = 14.53,
                        CategoryId = "categoryId20",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Men"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Product 4", //
                        Size = "S",
                        Material = "Cotton 100",
                        Description = "A new t-shirt Male from cotton",
                        Brand = "Old",
                        Price = 15.55,
                        CategoryId = "categoryId20",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Men"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Product 5", //
                        Size = "M",
                        Material = "Cotton 50",
                        Description = "A new t-shirt Male",
                        Brand = "Old",
                        Price = 17.55,
                        CategoryId = "categoryId20",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Men"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Product 6", //
                        Size = "4y",
                        Material = "Cotton",
                        Description = "A new t-shirt Kid",
                        Brand = "Kiddy",
                        Price = 19.55,
                        CategoryId = "categoryId29",
                        //Category = "tShirts",
                        //Subcategory = "shirts",
                        //GlobalCategory = "Clothes",
                        //TargetAudience = "Children"
                    },
                };
                context.Products.AddRange(clothes);
                context.SaveChanges();
            }
        }
    }
}

// the database with categories is created but when the new product is added
// by admin, and the category does not exist, the new field should be added.
// how to implement such checking for the field availability?
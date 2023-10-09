namespace ClothesShop;

public class Product

{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Size { get; set; }
    public string? Material { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public string? CategoryId { get; set; }
    public double? Price { get; set; }
    //public string GlobalCategory { get; set; } // clothes, shoes
    //public string SpecificCategory { get; set; } // trousers, jackets etc.
    //public string SubCategory { get; set; } // trousers: jeans, classic
    //public string TargetAudience { get; set; } // men, women, children
}

// створити клас Product
// створити у контролері(можна в конструкторі) список-приклад продуктів
// змінити метод get, щоб він повертав список продуктів

// person can shooce ALL: it shows all products
// choose by Target Audience: Men, Women, Kids, shows only items for the chosen TA
// choose by GlobalCategory (clothes, shoes, accessories)
// choose by Category (jackets, trousers, shirts)
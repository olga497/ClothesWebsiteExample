using ClothesShop.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    
    private static readonly string[] WomenClothes = new[]
    {
        "Jacket", "Jeans", "WinterDress", "SummerDress", "TshirtOne", "TshirtTwo"
    };

    private readonly ILogger<ProductController> _logger;
    private readonly IRepository _repository;

    public ProductController(ILogger<ProductController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [Authorize]
    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
       return _repository.Get();
    }

    [HttpGet(Name = "GetProductById")]
    public Product GetById(string Id)
    {
        return _repository.GetById(Id);
    }

    [HttpPut(Name = "UpdateProduct")]
    public void Update(string Id)
    {
       var product = _repository.GetById(Id);
        product.Description += " Updated";
        _repository.Save();
       
    }

    [Authorize]
    [HttpPost(Name = "InsertProduct")]
    public IActionResult Insert(Product p)
    {
        //var products = new List<Product>();
        //foreach (string item in WomenClothes)
        //{
        //var Clothes = new Product
        //{
        //    ID = Guid.NewGuid().ToString(),//unique identifier
        //    Title = p.Title,
        //    Size = p.Size,
        //    Material = p.Material,
        //    Description = p.Description,
        //    Brand = p.Brand,
        //    Category = p.Category,
        //    Subcategory = p.Subcategory,
        //    GlobalCategory = p.GlobalCategory,
        //    TargetAudience = p.TargetAudience
        //};

        //products.Add(Clothes);
        //}

        //_repository.Insert(products.First());


        if (p != null)
        {
            // Generate a unique ID for the product
            p.Id = Guid.NewGuid().ToString(); // Assuming the ID property is of type string

            // Assuming the _repository variable is correctly initialized to handle database operations.
            _repository.Insert(p);
            _repository.Save();
            return Ok();
        }
        else
        {
            // Handle the case when the product data is not provided in the request.
            return BadRequest("Product data is missing.");
        }
        //_repository.Insert(p);
        //_repository.Save();
        //return Ok();
    }

    [HttpDelete(Name = "DeleteProduct")]
    public void Delete(string Id)
    {
        _repository.Delete(Id);
       // _repository.Save(); // перенести в репозиторій
    }

}


// Roles: user, admin, WH, analytic, shipper.

// Access:
// - user has access only to website info and his personal page.
// - admin has access to Products, Users, Orders. Can edit or delete info but cannot delete a user.
// - WH has access only to WH.
// - analytic has reading access only to WH and Orders (without data of users).
// - shipper has access to Shipments table (orders with status Sent, quantity, delivery address, no user name, no price).
// Can change order status to Delivered. Orders do not disappear from the table.


//  Tasks to be performed by an administrator in the database:
//  Tables access with the opportunitites listed below:
//  Products, Categories (with all fields except for Id with opportunity to edit
//  select list: GlobalCategory, SpecificCategory, Subcategory), Orders, Users, WH (all the items with quantities,
// when shopping cart is being formed the quantity is checked in WH table. If 0 then the item cannot be chosen for the shopping cart. 
//  1. Search for product in the database (the same search criteria as
//  for the online search for the user: by all the fields or in a specific field,
//  search is not case sensitive).
//  2. As product found, or just from the visible list with details:
//  Possibility to add new products to the shop database.
//  3. As product found, or just from the visible list with details:
//  Possibility to delete a product from the database. 
//  4. Can update any field in the database but for ID.
//  5. Can generate reports:
//  5.1. Report on the items sold for the period and total (from Orders table):
//  - items quantity by year/ month/ week/ day, total,
//  - sales sum (cost items summed up) by year/ month/ week/ day,
//  - items quantity by TA (male, female, children) by year/ month/ week/ day, total,
//  - items sum (cost items summed up) by TA (male, female, children) by year/ month/ week/ day, total,
//  - items quantity by GlobalCategory by year/ month/ week/ day, total,
//  - items sum by GlobalCategory by year/ month/ week/ day, total,
//  - items quantity by SpecificCategory by year/ month/ week/ day, total,
//  - items sum by SpecificCategory by year/ month/ week/ day, total,
//  - items quantity by GlobalCategory and inside by SpecificCategory by year/ month/ week/ day, total,
//  - items sum by GlobalCategory and inside by SpecificCategory by year/ month/ week/ day, total,
//  - items quantity by SubCategory by year/ month/ week/ day, total,
//  - items sum by SubCategory by year/ month/ week/ day, total,
//  - items quantity by GlobalCategory and inside by SpecificCategory and inside by SubCategory by year/ month/ week/ day, total,
//  - items sum by GlobalCategory and inside by SpecificCategory and inside by SubCategory by year/ month/ week/ day, total,

// 5.2. Analysis of returns:
// similar reports to orders but based on returns table.

// 5.3. Reports on orders quantity and sum:
// - orders quantity by year/ month/ week/ day, total,
// - orders sum by year/ month/ week/ day, total

// 5.4. Reports on returns by quantity and sum:
// - returns quantity by year/ month/ week/ day, total,
// - returns sum by year/ month/ week/ day, total

// 5.5. Income calculation:
// - (orders sum - returns sum) by year/ month/ week/ day, total

// 5.6. Performance calculation:
// - orders quantity increase (year to previous year/ month to previous month/
// week to previous week / day to previous day in percent;
// - orders sum increase (year to previous year/ month to previous month/
// week to previous week / day to previous day in percent;
// - same statistics but increase sorted by TA, GlobalCategory, Spec.Category,
// SubCategory;
// - by GlobalCategory and inside by Spec. Category;
// - by GlobalCategory and inside by Spec. Category and inside by SubCategory,
// - opportunity to choose a specific GlobalCategory, Spec. Cat. and SubCategory or all of them
// that Admin is interested in.

// 6. Building charts based on the selected data. Bar charts, pie charts.

// 7. User personal reporting:
// 7.1. Orders:
// - number by year, month.
// - sum by year, month.

// 8. User should be able to change and update his information: name, surname, email, tel. number, address, delete his account, restore his account.
// 9. User can log in by data in the system or by social media account (gmail, microsoft) and merge all his way of logging in
// so that he is recognized as 1 user.
// 10. User can gather items into shopping cart, edit shopping cart, delete shopping cart: choose items and their quantity,
// change quantity, remove items from the shopping cart.
// 11. User can create an order from the shopping cart, edit order: change quantity of items, remove items,
// choose way of delivery, add discount code if available, edit address (if there is in a personal cabinet, address is added
// ) make payment via klarna.

// 12. Logging in is not compulsory for purchase but if a user is not logged in, statistical data is not gathered for the user,
// but gathered for the reports of the administrator.

// 13. Warehouse access:
// 13.1. As order is placed a warehouse receives the info with order info: all items w/o prices, but a WH code, quantity,
// delivery address. WH can change status of order to Sent.
// 13.2. As WH changes the status of the order to Sent, it disappears from the database. Status of order is changed in Orders database. 

// 14. All the statuses of the order are changed in the personal page of the user.
// Order statuses: Placed, Sent, Delivered.
// as user places the order, the status is changed to Placed; as WH changes on their page, status is changed to Sent;
// Shipper can change the status from Sent to Delivered. 
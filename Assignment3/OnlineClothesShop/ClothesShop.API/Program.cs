using System.Text;
using ClothesShop;
using ClothesShop.Infrastructure.Identity;
using ClothesShop.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<ProductDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddLogging();


// For Entity Framework  
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=Identity;User Id=sa;Password=Lesson123!;TrustServerCertificate=true;"));


// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ProductDBContext>()
    .AddDefaultTokenProviders();

// Adding Authentication  
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


builder.Services.AddAuthorization();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
    {
    var services = scope.ServiceProvider;
    var context = services.GetService<ProductDBContext>();
    var logger = services.GetService<ILogger<Program>>();
    logger.LogInformation(context.Database.GetConnectionString());
    if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
    {
        context.Database.Migrate(); // creates migrations 
        DataSeeder.SeedClothes(context); // and seeds data

        //comment out multiple lines: command + shift + 7

        // need to call a method SeedClothes from the DataSeeder class 

        //context.Products.Add(new Product // перенести в окремий клас DataSeeder
        //{
        //    ID = Guid.NewGuid().ToString(),//unique identifier
        //    Title = "Product from Program.cs", //
        //    Size = "M",
        //    Material = "Cotton",
        //    Description = "A new t-shirt",
        //    Brand = "New",
        //    Category = "tShirts",
        //    Subcategory = "shirts",
        //    GlobalCategory = "Clothes",
        //    TargetAudience = "Women"
        //});
        //context.SaveChanges();
    }
}


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
app.UseCors();

//app.UseHttpsRedirection();

app.UseRouting();// added


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


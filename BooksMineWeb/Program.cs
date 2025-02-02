using BooksMine.DataAccess.Repository;
using BooksMine.DataAccess.Repository.interfaces;
using BooksMine.Models.Models;
using BooksMine.Utility;
using BooksMineWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>(); 

builder.Services.AddScoped<ICategoryRepo , CategoryRepo>();
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
builder.Services.AddScoped<IPublisherRepo, PublisherRepo>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("stripe"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("stripe:SecretKey").Get<String>();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

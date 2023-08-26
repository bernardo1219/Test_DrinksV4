using Microsoft.EntityFrameworkCore;
using Test_DrinksV2.Models.Config;
using Test_DrinksV4.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TestContextcs>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BD_test_drinks")));

// Injection httpClient to searchs
builder.Services.AddHttpClient<CocktailController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

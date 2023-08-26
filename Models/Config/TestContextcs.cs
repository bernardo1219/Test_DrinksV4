using Microsoft.EntityFrameworkCore;
using Test_DrinksV4.Models;

namespace Test_DrinksV2.Models.Config
{
    public class TestContextcs : DbContext
    {
        public TestContextcs(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FavoriteDrink> FavoritesDrinks { get; set; }
    }
}

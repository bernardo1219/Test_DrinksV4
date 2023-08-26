using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test_Drinks.Models;
using Test_DrinksV2.Models.Config;

namespace Test_DrinksV4.Models
{
    [Table("favorite_drinks")]
    public class FavoriteDrink : Cocktail
    {
        [Key]
        public int Id_favorite_drink { get; set; }


        public static FavoriteDrink? GetPorIdDrink(TestContextcs dbContext, int idDrink)
        {
            var query = from emp in dbContext.FavoritesDrinks
                        where emp.idDrink == idDrink
                        select emp;
            return query.Any() ? query.First() : null;
        }

        public static void Save(TestContextcs dbContext, FavoriteDrink cocktail)
        {
            dbContext.FavoritesDrinks.Add(cocktail);
            dbContext.SaveChanges();
        }

        public static List<FavoriteDrink> GetAll(TestContextcs dbContext)
        {
            var query = dbContext.FavoritesDrinks.OrderBy(u => u.strDrink);
            return query.Count() > 0 ? query.ToList() : new List<FavoriteDrink>();
        }

        public static void Delete(TestContextcs dbContext, FavoriteDrink cocktail)
        {
            dbContext.Entry(cocktail).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}

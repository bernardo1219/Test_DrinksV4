using Microsoft.AspNetCore.Mvc;
using Test_Drinks.Models;
using Test_DrinksV2.Models.Config;
using Test_DrinksV4.Lib;
using Test_DrinksV4.Models;

namespace Test_DrinksV4.Controllers
{
    public class CocktailController : Controller
    {
        private readonly HttpClient _client;
        private readonly TestContextcs _testContext;

        public CocktailController(HttpClient client, TestContextcs testContext)
        {
            _client = client;
            _testContext = testContext;
        }

        /// <summary>
        /// Cocktails are obtained by a search parameter and type of search 
        /// </summary>
        [HttpGet]
        public JsonResult GetCocktails(string param, TypeSearchCocktail.Types typeSearch)
        {
            List<Cocktail> cocktails = new();
            CocktailsData cocktailsData = new(_client);

            switch (typeSearch)
            {
                case TypeSearchCocktail.Types.BY_NAME:
                    cocktails = cocktailsData.GetByName(param);
                    break;
                case TypeSearchCocktail.Types.BY_FIRST_LETTER:
                    cocktails = cocktailsData.GetByFirstLetter(param);
                    break;
                case TypeSearchCocktail.Types.BY_ID:
                    cocktails = cocktailsData.GetByID(int.Parse(param));
                    break;
                case TypeSearchCocktail.Types.BY_RANDOM:
                    cocktails = cocktailsData.GetByRandom();
                    break;
                case TypeSearchCocktail.Types.BY_INGREDIENT:
                    cocktails = cocktailsData.GetByIngredent(param);
                    break;
                case TypeSearchCocktail.Types.BY_ALCOHOL_FILTER:
                    cocktails = cocktailsData.GetByAlcoholicFilter(param);
                    break;
                case TypeSearchCocktail.Types.BY_CATEGORY:
                    cocktails = cocktailsData.GetByCategory(param);
                    break;
                case TypeSearchCocktail.Types.BY_GLASS:
                    cocktails = cocktailsData.GetByGlass(param);
                    break;
            }
            return Json(cocktails != null ? cocktails.OrderBy(c => c.strDrink).ToList() : new List<Cocktail>());
        }

        /// <summary>
        /// All ingredients are obtained
        /// </summary>
        [HttpGet]
        public JsonResult GetIngredientsCocktails()
        {
            IngredientsData ingredientsData = new(_client);
            List<Ingredient> ingredients = ingredientsData.GetData("list.php?i=list");
            return Json(ingredients != null ? ingredients.OrderBy(i => i.strIngredient1).ToList() : new List<Ingredient>());
        }

        /// <summary>
        /// Save new favorite drink
        /// </summary>
        [HttpPost]
        public string setFavoriteDrink(int idDrink)
        {
            CocktailsData cocktailsData = new(_client);
            List<Cocktail> cocktails = cocktailsData.GetByID(idDrink);
            if (cocktails != null && cocktails.Count == 1)
            {
                FavoriteDrink favoriteDrink = new();
                favoriteDrink.idDrink = cocktails.First().idDrink;
                favoriteDrink.strDrink = cocktails.First().strDrink;
                favoriteDrink.strDrinkThumb = cocktails.First().strDrinkThumb;

                FavoriteDrink.Save(_testContext, favoriteDrink);
                return "OK";
            }
            throw new Exception("The cocktail doesnt exits");
        }

        /// <summary>
        /// Get all favorite drinks added
        /// </summary>
        [HttpGet]
        public JsonResult GetAllFavoriteDrinks()
        {
            List<FavoriteDrink> drinks = FavoriteDrink.GetAll(_testContext);
            return Json(drinks != null ? drinks.OrderBy(i => i.strDrink).ToList() : new List<FavoriteDrink>());
        }

        /// <summary>
        /// Delete favorite drink added
        /// </summary>
        [HttpDelete]
        public string DeleteFavoriteDrink(int idDrink)
        {
            FavoriteDrink? favoriteDrink = FavoriteDrink.GetPorIdDrink(_testContext, idDrink);
            if (favoriteDrink != null)
            {
                FavoriteDrink.Delete(_testContext, favoriteDrink);
                return "OK";
            }
            return "ERROR";
        }

    }
}

using Newtonsoft.Json;
using Test_Drinks.Models;
using Test_DrinksV2.Models;

namespace Test_DrinksV4.Lib
{
    public class CocktailsData : SearchCocktails
    {
        public CocktailsData(HttpClient client) 
        {
            this.Client = client;
        }

        public override List<Cocktail> GetByAlcoholicFilter(string alcoholicFilter)
        {
            string path = $"filter.php?a={alcoholicFilter}";
            return GetData(path);
        }

        public override List<Cocktail> GetByCategory(string category)
        {
            string path = $"filter.php?c={category}";
            return GetData(path);
        }

        public override List<Cocktail> GetByFirstLetter(string firstLetter)
        {
            string path = $"search.php?f={firstLetter}";
            return GetData(path);
        }

        public override List<Cocktail> GetByGlass(string glass)
        {
            string path = $"filter.php?g={glass}";
            return GetData(path);
        }

        public override List<Cocktail> GetByID(int id)
        {
            string path = $"lookup.php?i={id}";
            return GetData(path);
        }

        public override List<Cocktail> GetByIngredent(string ingredient)
        {
            string path = $"filter.php?i={ingredient}";
            return GetData(path);
        }

        public override List<Cocktail> GetByName(string name)
        {
            string path = $"search.php?s={name}";
            return GetData(path);
        }

        public override List<Cocktail> GetByRandom()
        {
            string path = $"random.php";
            return GetData(path);
        }

        private List<Cocktail> GetData (string path)
        {
            string dataJSON = ExecuteQuery(path);
            Drinks? drinks = JsonConvert.DeserializeObject<Drinks>(value: dataJSON);
            return drinks != null ? drinks.drinks : new List<Cocktail>();
        }
    }
}

using Microsoft.Identity.Client;
using Test_Drinks.Models;

namespace Test_DrinksV4.Lib
{
    public abstract class SearchCocktails : GeneralSearch
    {
        public abstract List<Cocktail> GetByName(string name);

        public abstract List<Cocktail> GetByFirstLetter(string firstLetter);

        public abstract List<Cocktail> GetByID (int id);

        public abstract List<Cocktail> GetByRandom();

        public abstract List<Cocktail> GetByIngredent(string ingredient);

        public abstract List<Cocktail> GetByAlcoholicFilter(string alcoholicFilter);

        public abstract List<Cocktail> GetByCategory(string category);

        public abstract List<Cocktail> GetByGlass(string glass);
    }
}

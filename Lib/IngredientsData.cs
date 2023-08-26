using Newtonsoft.Json;
using Test_DrinksV4.Models;

namespace Test_DrinksV4.Lib
{
    public class IngredientsData : GeneralSearch
    {   

        public IngredientsData(HttpClient client) 
        { 
            this.Client = client;
        }

        public List<Ingredient> GetData(string path)
        {
            string dataJSON = ExecuteQuery(path);
            DrinkIngredients? ingredients = JsonConvert.DeserializeObject<DrinkIngredients>(value: dataJSON);
            return ingredients != null ? ingredients.drinks : new List<Ingredient>();
        }
    }
}


using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Drinks.Models
{
    public class Cocktail
    {
        public int idDrink { get; set; }

        public string? strDrink { get; set; }
        
        [NotMapped]
        public string? strDrinkAlternate { get; set; }

        [NotMapped]
        public string? strTags { get; set; }

        [NotMapped]
        public string? strVideo { get; set; }

        [NotMapped]
        public string? strCategory { get; set; }

        [NotMapped]
        public string? strIBA { get; set; }

        [NotMapped]
        public string? strAlcoholic { get; set; }

        [NotMapped]
        public string? strGlass { get; set; }

        [NotMapped]
        public string? strInstructions { get; set; }

        [NotMapped]
        public string? strInstructionsES { get; set; }

        [NotMapped]
        public string? strInstructionsDE { get; set; }

        [NotMapped]
        public string? strInstructionsFR { get; set; }

        [NotMapped]
        public string? strInstructionsIT { get; set; }

        public string? strDrinkThumb { get; set; }

        [NotMapped]
        public string? strIngredient1 { get; set; }

        [NotMapped]
        public string? strIngredient2 { get; set; }

        [NotMapped]
        public string? strIngredient3 { get; set; }

        [NotMapped]
        public string? strIngredient4 { get; set; }

        [NotMapped]
        public string? strIngredient5 { get; set; }

        [NotMapped]
        public string? strIngredient6 { get; set; }

        [NotMapped]
        public string? strIngredient7 { get; set; }

        [NotMapped]
        public string? strIngredient8 { get; set; }

        [NotMapped]
        public string? strIngredient9 { get; set; }

        [NotMapped]
        public string? strIngredient10 { get; set; }

        [NotMapped]
        public string? strIngredient11 { get; set; }

        [NotMapped]
        public string? strIngredient12 { get; set; }

        [NotMapped]
        public string? strIngredient13 { get; set; }

        [NotMapped]
        public string? strIngredient14 { get; set; }

        [NotMapped]
        public string? strIngredient15 { get; set; }

        [NotMapped]
        public string? strMeasure1 { get; set; }

        [NotMapped]
        public string? strMeasure2 { get; set; }

        [NotMapped]
        public string? strMeasure3 { get; set; }

        [NotMapped]
        public string? strMeasure4 { get; set; }

        [NotMapped]
        public string? strMeasure5 { get; set; }

        [NotMapped]
        public string? strMeasure6 { get; set; }

        [NotMapped]
        public string? strMeasure7 { get; set; }

        [NotMapped]
        public string? strMeasure8 { get; set; }

        [NotMapped]
        public string? strMeasure9 { get; set; }

        [NotMapped]
        public string? strMeasure10 { get; set; }

        [NotMapped]
        public string? strMeasure11 { get; set; }

        [NotMapped]
        public string? strMeasure12 { get; set; }

        [NotMapped]
        public string? strMeasure13 { get; set; }

        [NotMapped]
        public string? strMeasure14 { get; set; }

        [NotMapped]
        public string? strMeasure15 { get; set; }

        [NotMapped]
        public string? strImageSource { get; set; }

        [NotMapped]
        public string? strImageAttribution { get; set; }

        [NotMapped]
        public string? strCreativeCommonsConfirmed { get; set; }

        [NotMapped]
        public DateTime? dateModified { get; set; }
    }
}

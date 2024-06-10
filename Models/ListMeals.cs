using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Models
{
    public class MealShort
    {
        public string? strMeal { get; set; }
        public string? strMealThumb { get; set; }
        public string? idMeal { get; set; }
    }

    public class ListMeals
    {
        public List<MealShort>? meals { get; set; }
    }
}

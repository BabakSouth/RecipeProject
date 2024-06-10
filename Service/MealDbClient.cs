using Newtonsoft.Json;
using RecipeProject.Models;

namespace RecipeProject.Service
{
    public class MealDbClient
    {
        private readonly HttpClient _httpClient;
        public MealDbClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/") };
        }
        public async Task<Categories?> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("categories.php");
                return JsonConvert.DeserializeObject<Categories>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return null;
            }
        }

        public async Task<ListMeals?> GetMealsByCategoryAsync(string category)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"filter.php?c={category}");
                return JsonConvert.DeserializeObject<ListMeals>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching meals: {ex.Message}");
                return null;
            }
        }

        public async Task<ListDetailMeals?> GetMealDetailsAsync(string mealId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"lookup.php?i={mealId}");
                return JsonConvert.DeserializeObject<ListDetailMeals>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching meal details: {ex.Message}");
                return null;
            }
        }

    }
}

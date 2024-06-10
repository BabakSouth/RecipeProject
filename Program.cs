// See https://aka.ms/new-console-template for more information
using RecipeProject.Service;

Console.WriteLine("Hello, World!");

var client = new MealDbClient();

// List categories
var categories = await client.GetCategoriesAsync();
if (categories != null)
{
    Console.WriteLine("Categories:");
    foreach (var category in categories.categories)
    {
        Console.WriteLine($"{category.strCategory} - {category.strCategoryDescription}");
    }
}
else
{
    Console.WriteLine("Failed to fetch categories.");
}

// List meals in a category (e.g., "Seafood")
Console.WriteLine("\nEnter a category to list meals:");
string categoryToSearch = Console.ReadLine();
var meals = await client.GetMealsByCategoryAsync(categoryToSearch);
if (meals != null)
{
    if (meals.meals != null)
    {
        Console.WriteLine($"\nMeals in category {categoryToSearch}:");

        foreach (var meal in meals.meals)
        {
            Console.WriteLine($"{meal.strMeal} - {meal.strMealThumb}");
        }
    }
    else
    {
        Console.WriteLine("Failed to fetch meals.");
    }
}
else
    Console.WriteLine("Failed to fetch meals.");

// Get meal details like 52772
Console.WriteLine("\nEnter a meal ID to get details:");
string mealId = Console.ReadLine();
var mealDetails = await client.GetMealDetailsAsync(mealId);
if (mealDetails != null)
{
    if (mealDetails.meals != null)
    {
        if (mealDetails != null && mealDetails.meals.Any())
        {
            var mealDetail = mealDetails.meals.FirstOrDefault();
            Console.WriteLine($"\nMeal: {mealDetail.strMeal}");
            Console.WriteLine($"Image: {mealDetail.strMealThumb}");
            Console.WriteLine($"Instructions: {mealDetail.strInstructions}");
        }
    }
    else
    {
        Console.WriteLine("Failed to fetch meal details.");
    }
}
else
    Console.WriteLine("Failed to fetch meal details.");

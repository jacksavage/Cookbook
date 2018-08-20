using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cookbook.Models;
using System.Linq;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        private List<Recipe> RecipeService;

        public HomeController()
        {
            RecipeService = GetRecipes();
        }

        public IActionResult Index()
        {
            // todo get all recipes and pass to the view
            return View(RecipeService);
        }

        public IActionResult AddRecipe() { return View(); }

        public IActionResult SubmitRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var successful = true; // todo add item through recipe service
            if (!successful) return BadRequest("Could not add item.");
            return RedirectToAction("Index");
        }

        private List<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe>();

            var recipe = new Recipe();
            recipe.ID = 0;
            recipe.Author = "Jack Savage";
            recipe.DateAdded = DateTime.Now;
            recipe.Title = "Hamburger";
            recipe.Description = "This will hit the freakin spot. I promise you.";
            recipe.Tags = new List<string>(new[] { "american", "burgers", "grilling" });
            recipe.Directions = new List<Direction>(new[] {
                new Direction() { Order = 1, Content = "cook the meat" },
                new Direction() { Order = 2, Content = "build your sammy" },
                new Direction() { Order = 3, Content = "eat it" },
            });
            recipe.Ingredients = new List<Ingredient>(new[] {
                new Ingredient() { Quantity = "1 pound", Name = "ground beef" },
                new Ingredient() { Quantity = "1", Name = "wheat bun" },
                new Ingredient() { Quantity = "1 head", Name = "lettuce" },
                new Ingredient() { Quantity = "1 slice", Name = "cheese" }
            });

            recipes.Add(recipe);

            return recipes;
        }

        public IActionResult Recipe(int id)
        {
            var recipe = RecipeService.First(r => r.ID == id);
            return View(recipe);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

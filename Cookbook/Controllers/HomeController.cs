using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // todo get all recipes and pass to the view
            var recipes = new List<Recipe>();
            return View(recipes);
        }

        public IActionResult Recipe(int id)
        {
            // todo get one recipe and pass it to view
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

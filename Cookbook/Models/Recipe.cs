using System;
using System.Collections.Generic;

namespace Cookbook.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public string Author { get; set; }

        public DateTime DateAdded { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Direction> Directions { get; set; }

        public List<string> ImagePaths { get; set; }
    }
}

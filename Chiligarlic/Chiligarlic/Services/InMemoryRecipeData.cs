using Chiligarlic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.Services
{
    public class InMemoryRecipeData : IRecipeData
    {
        public IEnumerable<Recipe> GetAll()
        {
            return _recipes.OrderBy(r => r.Name);
        }

        public Recipe Get(int Id)
        {
            return _recipes.FirstOrDefault(r => r.Id == Id);
        }

        public Recipe Add(Recipe recipe)
        {
            recipe.Id = _recipes.Max(r => r.Id) + 1;
            _recipes.Add(recipe);
            return recipe;
        }

        public InMemoryRecipeData()
        {
            _recipes = new List<Recipe>
            {
            new Recipe { Id = 1, Name = "Fettucini Alfredo"},
            new Recipe { Id = 2, Name = "Pecan Pie"},
            new Recipe { Id = 3, Name = "Avocado Veggie Burger"}
            };
        }

        List<Recipe> _recipes;
    }
}

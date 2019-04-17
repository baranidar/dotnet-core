using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiligarlic.Data;
using Chiligarlic.Models;

namespace Chiligarlic.Services
{
    public class SqlRecipeData : IRecipeData
    {
        private ChiliGarlicDbContext _context;

        public SqlRecipeData(ChiliGarlicDbContext context)
        {
            _context = context;
        }
        public Recipe Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public Recipe Get(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.OrderBy(r => r.Name);
        }
    }
}

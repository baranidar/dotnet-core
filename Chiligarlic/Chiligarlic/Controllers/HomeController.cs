using Chiligarlic.Models;
using Chiligarlic.Services;
using Chiligarlic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.Controllers
{
    public class HomeController :Controller
    {
        private IRecipeData _recipeData;
        private IGreeter _greeter;

        public HomeController(IRecipeData RecipeData, IGreeter greeter)
        {
            _recipeData = RecipeData;
            _greeter = greeter;
        }   

        public  IActionResult Index()
        {
            //var model = new Recipe { id = 1, Name = "Fettucini Alfredo" };
            //var model = _recipeData.GetAll();
            var model = new HomeIndexViewModel();
            model.Recipes = _recipeData.GetAll();
            model.CurrentMessage = _greeter.GetMessageofTheDay();
            return View(model);
        }

        public IActionResult Details(int Id)
        {
            //return Content(Id.ToString());
            var model = _recipeData.Get(Id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecipeEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRecipe = new Recipe();
                newRecipe.Name = model.Name;
                newRecipe.Timeofday = model.Timeofday;
                newRecipe = _recipeData.Add(newRecipe);

                //return View("Details", newRecipe);
                return RedirectToAction(nameof(Details), new { id = newRecipe.Id });
            }
            else
            {
                return View();
            }
        }
    }
}


using Chiligarlic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public string CurrentMessage { get; set; }
    }
}

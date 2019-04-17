using Chiligarlic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.ViewModels
{
    public class RecipeEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public TimeofdayType Timeofday  { get; set; }
    }
}

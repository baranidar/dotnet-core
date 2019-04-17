using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.Controllers
{
    //about

    [Route("company/[controller]/[action]")]
    public class AboutController
    {

        public string Phone()
        {
            return "+1  2817910010";
        }

        public string Address()
        {
            return "USA";
        }
    }
}

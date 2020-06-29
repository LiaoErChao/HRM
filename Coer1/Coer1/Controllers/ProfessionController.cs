using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Coer1.Controllers
{
    public class ProfessionController : Controller
    {
        public IActionResult profession_design()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Coer1.Controllers
{
    public class MajorController : Controller
    {
        public IActionResult major()
        {
            return View();
        }

        public IActionResult major_add() {
            return View();
        }
    }
}
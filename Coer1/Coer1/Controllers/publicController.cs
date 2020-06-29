using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Coer1.Controllers
{
    public class publicController : Controller
    {
        public IActionResult publi_char()
        {
            return View();
        }

        public IActionResult public_char_add() {

            return View();
        }
    }
}
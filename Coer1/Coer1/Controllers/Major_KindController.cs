using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Coer1.Controllers
{
    public class Major_KindController : Controller
    {
        public IActionResult major_kind()
        {
            return View();
        }
        public IActionResult major_kind_add() {
            return View();
        }
    }
}
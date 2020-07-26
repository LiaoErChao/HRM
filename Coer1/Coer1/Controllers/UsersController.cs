using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;


namespace Coer1.Controllers
{
    public class UsersController : Controller
    {

        private readonly IuserBLL1 iub;

        public UsersController(IuserBLL1 iub) {
            this.iub = iub;
        }


        //登录
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(usersModel1 um) {

            int reslut =await iub.Login(um);
            if (ModelState.IsValid) {
                if (reslut > 0)
                {
                    HttpContext.Session.SetString("Uname", um.user_name);
                 
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(um);
                }
            }
            else {
                return View(um);
            }           
        }

        //主页
        public IActionResult Index() {

            return View();
        }

        public IActionResult left() {
            return View();
        }

        public IActionResult main()
        {
            return View();
        }

        public IActionResult top()
        {
            return View();
        }

    }
}
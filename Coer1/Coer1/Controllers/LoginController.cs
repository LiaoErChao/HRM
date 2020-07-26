using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Model;
using IBLL;
using EFEntity;

namespace Coer1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IusersBLL sa;
        private readonly IroleBLL iro;
        private readonly TescDbContext tesc;
        public LoginController(IusersBLL sa,IroleBLL iro,TescDbContext tesc)
        {
            this.sa = sa;
            this.iro = iro;
            this.tesc = tesc;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(usersModel um)
        {

            int reslut = await sa.Login(um);
            if (ModelState.IsValid)
            {
                if (reslut > 0)
                {
                    string name = sa.Ro(um);
                    HttpContext.Session.SetString("User_name", um.User_name);
                    List<roleModel> aa = await iro.RoleSelect();
                    foreach (roleModel item in aa) 
                    {
                        if (item.user_identity==name)
                        {
                            HttpContext.Session.SetString("Qid", item.r_id.ToString());
                        }
                    }
                    return Redirect("/Main/left");
                    //return Redirect("登陆成功");
                }
                else
                {
                    return Content("<script>alert('登录失败');</script>");
                }
            }
            else



              
            {
                return View(um);
            }
        }
    }
}

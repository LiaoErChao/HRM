using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coer1.Controllers
{
    public class PowerController : Controller
    {
        private readonly IusersBLL iub;
        private readonly IroleBLL iro;

        public PowerController(IusersBLL iub, IroleBLL iro) 
        {
            this.iub = iub;
            this.iro = iro;
        }
        [HttpGet]
        public IActionResult user_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_list(FenYeModel fen) 
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "";
            fen.KeyName = "user_id";
            fen.TableName = "users";
            List<usersModel> page = iub.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        public async Task<IActionResult> user_add() 
        {
            await NewMethod();
            return View();
        }
        private async Task NewMethod()
        {
            List<roleModel> list = await iro.RoleSelect();
            SelectList si1 = new SelectList(list, "r_id", "user_identity");
            ViewData["s"] = si1;
        }
        [HttpPost]
        public async Task<ActionResult> user_add(usersModel um)
        {
            int a = Convert.ToInt32(um.user_identity);
            List<roleModel> list1 = await iro.RoleSelect();
            foreach (roleModel item in list1)
            {
                if (item.r_id == a)
                {
                    um.user_identity = item.user_identity;
                };
            }

            if (ModelState.IsValid)
            {
                if (await iub.UserCreate(um) > 0)
                {
                    return RedirectToAction("user_list");
                }
                else
                {
                    await NewMethod();
                    return View(um);
                }
            }
            else
            {
                await NewMethod();
                return View(um);
            }
        }
        [HttpGet]
        public async Task<ActionResult> user_edit(int id)
        {
            usersModel list1 = iub.UserSelectBy(id);
            List<roleModel> list2 = await iro.RoleSelect();
            foreach (roleModel item in list2)
            {
                if (item.user_identity == list1.user_identity)
                {
                    list1.user_identity = Convert.ToString(item.r_id);
                }
            }
            await NewMethod();
            ViewData.Model = list1;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> user_edit(usersModel um)
        {
            int a = Convert.ToInt32(um.user_identity);
            List<roleModel> list1 = await iro.RoleSelect();
            foreach (roleModel item in list1)
            {
                if (item.r_id == a)
                {
                    um.user_identity = item.user_identity;
                }
            }

            if (ModelState.IsValid)
            {
                if (await iub.UserEdit(um) > 0)
                {
                    return RedirectToAction("user_list");
                }
                else
                {
                    ViewData.Model = um;
                    return View(um.User_id);
                }
            }
            else
            {
                ViewData.Model = um;
                return View(um.User_id);
            }

        }
        public async Task<IActionResult> Del(int id)
        {
            if (await iub.UserDelete(id) > 0)
            {
                
                return RedirectToAction("user_list");
            }
            else
            {
                return RedirectToAction("user_list");
            }
        }
    }
}

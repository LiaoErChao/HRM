using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace Coer1.Controllers
{
    public class SecondController : Controller
    {
        private readonly Iconfig_file_second_kindBLL1 icfsb;

        public SecondController(Iconfig_file_second_kindBLL1 icfsb) {
            this.icfsb = icfsb;        
        }
       
        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Load() {
            List<config_file_second_kindModel1> list =await icfsb.Load();

            return Content(JsonConvert.SerializeObject(list));
        }



        //下拉框显示
        [HttpGet]
        public async Task<IActionResult> register() {
            List<config_file_first_kindModel1> list = await icfsb.SelectYiJiJG();
            List<SelectListItem> list2 = new List<SelectListItem>();

            foreach (var item in list)
            {
                list2.Add(new SelectListItem { Text=item.first_kind_name,Value=item.first_kind_id.ToString()+","+item.first_kind_name});
            }
            ViewBag.a = list2;
         return View();
        }

        //添加
        public async Task<IActionResult> Add(config_file_second_kindModel1 cffskm)
        {
            if (ModelState.IsValid)
            {
                string[] z = cffskm.first_kind_id.Split(',');
                cffskm.first_kind_id = z[0];
                cffskm.first_kind_name = z[1];
                int result = await icfsb.ADD(cffskm);
                if (result > 0)
                {

                    return RedirectToAction("Index");
                }
                else
                {

                    List<config_file_first_kindModel1> list = await icfsb.SelectYiJiJG();
                    List<SelectListItem> list2 = new List<SelectListItem>();
                    foreach (var item in list)
                    {
                        list2.Add(new SelectListItem { Text = item.first_kind_name, Value = item.first_kind_id.ToString() + "," + item.first_kind_name });
                    }
                    ViewBag.a = list2;
                    return View(cffskm);
                }

            }
            else {

                List<config_file_first_kindModel1> list = await icfsb.SelectYiJiJG();
                List<SelectListItem> list2 = new List<SelectListItem>();
                foreach (var item in list)
                {
                    list2.Add(new SelectListItem { Text = item.first_kind_name, Value = item.first_kind_id.ToString() + "," + item.first_kind_name });
                }
                ViewBag.a = list2;
                return View(cffskm);

            }

            return View();
        }

        //修改查询

        public async Task<IActionResult> change(int id) {
            config_file_second_kindModel1 cfskm = await icfsb.Up(id);
            ViewData.Model = cfskm;
            return View();
        }

        //修改
        public async Task<IActionResult> Update(config_file_second_kindModel1 cfskm) {

            if (ModelState.IsValid)
            {
                int result = await icfsb.Update(cfskm);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cfskm);
                }
            }
            else {
                return View(cfskm);
            }        
        }

        //删除
        public async Task<IActionResult> Delete(int id) {
            int result = await icfsb.Delete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        
        }
    }
}
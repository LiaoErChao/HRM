using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coer1.Controllers
{
    public class ThirdController : Controller
    {
        private readonly Iconfig_file_third_kindBLL icftkb;
        public ThirdController(Iconfig_file_third_kindBLL icftkb) {
            this.icftkb = icftkb;      
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Load()
        {
            List<config_file_third_kindModel> list = await icftkb.Select();
            return Content(JsonConvert.SerializeObject(list));
        }


        //下拉查询
        [HttpGet]
        public async Task<IActionResult> register() {
            List<config_file_first_kindModel> list = await icftkb.SelectYiJiJG();
            List<SelectListItem> list2 = new List<SelectListItem>();

            foreach (var item in list)
            {
                list2.Add(new SelectListItem { Text = item.first_kind_name, Value = item.first_kind_id.ToString() + "," + item.first_kind_name });
            }
            ViewBag.a = list2;


            List<config_file_second_kindModel> list3 = await icftkb.SelectErJiJG();
            List<SelectListItem> list4 = new List<SelectListItem>();
            foreach (var item in list3)
            {
                list4.Add(new SelectListItem { Text=item.second_kind_name,Value=item.second_kind_id.ToString()+","+item.second_kind_name});
            }
            ViewBag.b = list4;
            return View();
        }

        //添加
        [HttpPost]
        public async Task<IActionResult> register(config_file_third_kindModel cftkm) {

            if (ModelState.IsValid)
            {
                string[] z = cftkm.first_kind_id.Split(',');
                cftkm.first_kind_id = z[0];
                cftkm.first_kind_name = z[1];
                string[] z2 = cftkm.second_kind_id.Split(',');
                cftkm.second_kind_id = z2[0];
                cftkm.second_kind_name = z2[1];
                int result = await icftkb.ADD(cftkm);
                if (result > 0)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    List<config_file_first_kindModel> list = await icftkb.SelectYiJiJG();
                    List<SelectListItem> list2 = new List<SelectListItem>();

                    foreach (var item in list)
                    {
                        list2.Add(new SelectListItem { Text = item.first_kind_name, Value = item.first_kind_id.ToString() + "," + item.first_kind_name });
                    }
                    ViewBag.a = list2;


                    List<config_file_second_kindModel> list3 = await icftkb.SelectErJiJG();
                    List<SelectListItem> list4 = new List<SelectListItem>();
                    foreach (var item in list3)
                    {
                        list4.Add(new SelectListItem { Text = item.second_kind_name, Value = item.second_kind_id.ToString() + "," + item.second_kind_name });
                    }
                    ViewBag.b = list4;

                    return View(cftkm);
                }
            }
            else {
                List<config_file_first_kindModel> list = await icftkb.SelectYiJiJG();
                List<SelectListItem> list2 = new List<SelectListItem>();

                foreach (var item in list)
                {
                    list2.Add(new SelectListItem { Text = item.first_kind_name, Value = item.first_kind_id.ToString() + "," + item.first_kind_name });
                }
                ViewBag.a = list2;


                List<config_file_second_kindModel> list3 = await icftkb.SelectErJiJG();
                List<SelectListItem> list4 = new List<SelectListItem>();
                foreach (var item in list3)
                {
                    list4.Add(new SelectListItem { Text = item.second_kind_name, Value = item.second_kind_id.ToString() + "," + item.second_kind_name });
                }
                ViewBag.b = list4;

                return View(cftkm);


            }


        }


        //修改查询
        [HttpGet]
        public async Task<IActionResult> change(int id) {
            ViewData.Model = await icftkb.UpSelect(id);
            return View();
        }

        //修改
        [HttpPost]
        public async Task<IActionResult> change(config_file_third_kindModel cftkm) {
            if (ModelState.IsValid) {
                int result = await icftkb.Update(cftkm);
                if (result > 0)
                {

                    return RedirectToAction("Index");
                }
                else {
                    return View(cftkm);
                }

            }
            else{
                return View(cftkm);
            }
        
        }

        //删除
        public async Task<IActionResult> Delete(int id) {
            int result =await icftkb.Delete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Index");
            }
        }
    }
}
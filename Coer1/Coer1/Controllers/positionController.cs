using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
namespace Coer1.Controllers
{
    public class positionController : Controller
    {

        private readonly Iconfig_file_third_kindBLL icftkb;
        private readonly Iconfig_file_second_kindBLL icfskb;
        public positionController(Iconfig_file_third_kindBLL icftkb) {
            this.icftkb = icftkb;
            
        }
        public IActionResult position_register()
        {
            return View();
        }

        
        //一级查询
        public  IActionResult YiJi() {
            List<config_file_first_kindModel1> list =  icftkb.SelectYiJiJG();
            return Content(JsonConvert.SerializeObject(list));
        }

        //二级查询
        public  IActionResult ErJi(string id) {
            List<config_file_second_kindModel1> list = icftkb.SelectErJiJG().Where(e=>e.first_kind_id==id).ToList();

            return Content(JsonConvert.SerializeObject(list));
        }
    }
}
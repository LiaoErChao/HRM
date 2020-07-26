using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using EFEntity;
using IDAO;
using DAO;
using IBLL;
using BLL;
using Newtonsoft.Json;
    namespace Coer1.Controllers
{
    public class TescController : Controller
    {

        private readonly Iconfig_file_first_kindBLL1  config;

        public TescController(Iconfig_file_first_kindBLL1 config) {
            this.config = config;
        
        }
        [HttpGet]
        public  IActionResult Index()
        {        
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Select() {

            List<config_file_first_kindModel1> list = await config.SelectAll();

            return Content(JsonConvert.SerializeObject(list));
        }

        public IActionResult register() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(config_file_first_kindModel1 ffkm) {

            if (ModelState.IsValid) {
                int result = await config.Add(ffkm);
                if (result > 0)
                {

                    return RedirectToAction("Index");

                }
                else {

                    return View(ffkm);
                }
            }
            else {

                return View(ffkm);
            }
            
        }


        public async Task<IActionResult> change(int id) {
            
            config_file_first_kindModel1 cffkm = await config.UpSelect(id);
            ViewData.Model = cffkm;
            return View();
        }

        public async Task<IActionResult> Update(config_file_first_kindModel1 cffkm) {


            if (ModelState.IsValid)
            {
                int result = await config.Update(cffkm);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cffkm);
                }
            }
            else {
                    return View(cffkm);
            }
        }


        public async Task<IActionResult> Delete(int id) {
            int result =await config.Delete(id);
            if (result>0) {

                return RedirectToAction("Index");
            }
            else{

                return View();
            }
        
        }
        
    }
}
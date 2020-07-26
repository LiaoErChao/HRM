using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Newtonsoft.Json;

namespace Coer1.Controllers
{
    public class TransferxcController : Controller
    {
        private readonly Iconfig_file_first_kindBLL1 icf;
        private readonly Iconfig_file_second_kindBLL ics;
        private readonly Iconfig_file_third_kindBLL ict;
        private readonly Ihuman_fileBLL hum;
        private readonly Imajor_changeBLL mc;
        private readonly Iconfig_majorbBLL cm;
        private readonly Iconfig_major_kindBLL cmk;
        private readonly Isalary_standardBLL ss;

        public TransferxcController(Iconfig_file_first_kindBLL1 cof, Iconfig_file_second_kindBLL cos, Iconfig_file_third_kindBLL cot, Ihuman_fileBLL hum, Imajor_changeBLL mc, Iconfig_major_kindBLL cmk, Iconfig_majorbBLL cm, Isalary_standardBLL ss)
        {
            this.icf = cof;
            this.ics = cos;
            this.ict = cot;
            this.hum = hum;
            this.mc = mc;
            this.cmk = cmk;
            this.cm = cm;
            this.ss = ss;
        }
        [HttpGet]
        public IActionResult locate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> locate(List<config_file_first_kindModel1> list)
        {
            list = await icf.SelectAll();
            List<config_major_kindModel1> list3 = cmk.Select();
            SelectList sl = new SelectList(list, "first_kind_name", "first_kind_name", "全部");
            SelectList sl3 = new SelectList(list3, "major_kind_name", "major_kind_name", "全部");
            ViewData["first"] = sl;
            ViewData["majork"] = sl3;
            if (sl3 != null)
            {
                HttpContext.Session.SetString("firstKindId", Request.Form["configThird.firstKindId"]);
                HttpContext.Session.SetString("secondKindId", Request.Form["configThird.secondKindId"]);
                HttpContext.Session.SetString("thirdKindId", Request.Form["configThird.thirdKindId"]);
                HttpContext.Session.SetString("Major_kindId", Request.Form["emajorRelease.Major_kindId"]);
                HttpContext.Session.SetString("Major_Id", Request.Form["emajorRelease.Major_Id"]);
                //DateTime starttime = Convert.ToDateTime(HttpContext.Session.SetString("starttime",Request.Form[""]);
                //DateTime endtime = Convert.ToDateTime(HttpContext.Session.SetString("endtime",Request.Form[]);
                HttpContext.Session.SetString("starttime", Request.Form["utilbean.startDate"]);
                HttpContext.Session.SetString("endtime",Request.Form["utilbean.endDate"]);
                return RedirectToAction("list");
            }
            else 
            {
                return RedirectToAction("locate");
            }
        }
        [HttpGet]
        public IActionResult list() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult list(FenYeModel fen) 
        {
            string firstKindId=  HttpContext.Session.GetString("firstKindId");
            string secondKindId = HttpContext.Session.GetString("secondKindId");
            string thirdKindId = HttpContext.Session.GetString("thirdKindId");
            string Major_kindId = HttpContext.Session.GetString("Major_kindId");
            string Major_Id = HttpContext.Session.GetString("Major_Id");
            DateTime starttime = Convert.ToDateTime(HttpContext.Session.GetString("starttime"));
            DateTime endtime = Convert.ToDateTime(HttpContext.Session.GetString("endtime"));


            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = $@" new_first_kind_id='{firstKindId}' and new_second_kind_id='{secondKindId}' and new_third_kind_id='{thirdKindId}' and major_kind_name='{Major_kindId}' and major_name='{Major_Id}' and regist_time>= '{starttime}' and check_time<= '{endtime}' and  check_status=1";
            //and regist_time>= '{starttime}' and check_time<= '{endtime}'
            fen.KeyName = "mch_id";
            fen.TableName = "major_change";
            List<major_changeModel> page = mc.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        public IActionResult detail(int id) 
        {
            major_changeModel hfm = mc.SelById(id);
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewData.Model = hfm;
            return View();
        }
        public ActionResult Index1()
        {
            HttpContext.Session.SetString("fristname", HttpContext.Request.Form["configThird.firstKindId"]);
            HttpContext.Session.SetString("senconname", HttpContext.Request.Form["configThird.secondKindId"]);
            HttpContext.Session.SetString("thirdname", HttpContext.Request.Form["configThird.thirdKindId"]);
            HttpContext.Session.SetString("starttime", HttpContext.Request.Form["utilbean.startDate"]);
            HttpContext.Session.SetString("endtime", HttpContext.Request.Form["utilbean.endDate"]);
            HttpContext.Session.SetString("mk", HttpContext.Request.Form["emajorRelease.Major_kindId"]);
            HttpContext.Session.SetString("m", HttpContext.Request.Form["emajorRelease.Major_Id"]);
            return RedirectToAction("list");
        }
        public IActionResult first()
        {
            List<config_file_first_kindModel1> list = icf.Selects();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult first1()
        {
            string f = HttpContext.Session.GetString("f").ToString();
            string s = HttpContext.Session.GetString("s").ToString();
            List<config_file_first_kindModel1> list = icf.Selects();
            if (s == null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].first_kind_name == f)
                    {
                        list.Remove(list[i]);
                        break;
                    }
                }
            }
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult CMK()
        {
            List<config_major_kindModel1> list = cmk.Select();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult SS()
        {
            List<salary_standardModel> list = ss.Select().Where(e => e.check_status == 0).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult SS1(string id)
        {
            List<salary_standardModel> list = ss.Select().Where(e => e.check_status == 0 & e.standard_name == id).ToList();
            return Json(list[0].salary_sum);
        }
        public IActionResult CM(string id)
        {
            List<config_majorModel1> list = cm.Select().Where(e => e.major_kind_name == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult Selfirst(string id)
        {

            List<config_file_second_kindModel1> list = ics.Loads().Where(e => e.first_kind_id == id).ToList();

            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult Selfirst1(string id)
        {
            string s = HttpContext.Session.GetString("s").ToString();
            string t = HttpContext.Session.GetString("t").ToString();

            List<config_file_second_kindModel1> list = ics.Loads().Where(e => e.first_kind_name == id).ToList();
            if (t == null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].second_kind_name == s)
                    {
                        list.Remove(list[i]);
                        break;
                    }
                }
            }

            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult ThiSecond(string id, string id2)
        {
            List<config_file_third_kindModel1> list = ict.Selectt().Where(e => e.second_kind_id == id && e.first_kind_id == id2).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        public IActionResult ThiSecond1(string id, string id2)
        {
            string t = HttpContext.Session.GetString("t").ToString();
            List<config_file_third_kindModel1> list = ict.Selectt().Where(e => e.second_kind_name == id && e.first_kind_name == id2).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].third_kind_name == t)
                {
                    list.Remove(list[i]);
                    break;
                }
            }
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
    }
}

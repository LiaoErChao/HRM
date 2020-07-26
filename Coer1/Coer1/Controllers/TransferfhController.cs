using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFEntity.Configer;

namespace Coer1.Controllers
{
    public class TransferfhController : Controller
    {
        private readonly Iconfig_file_first_kindBLL1 icf;
        private readonly Iconfig_file_second_kindBLL ics;
        private readonly Iconfig_file_third_kindBLL ict;
        private readonly Ihuman_fileBLL hum;
        private readonly Imajor_changeBLL mc;
        private readonly Iconfig_majorbBLL cm;
        private readonly Iconfig_major_kindBLL cmk;
        private readonly Isalary_standardBLL ss;

        public TransferfhController(Iconfig_file_first_kindBLL1 cof, Iconfig_file_second_kindBLL cos, Iconfig_file_third_kindBLL cot, Ihuman_fileBLL hum, Imajor_changeBLL mc, Iconfig_major_kindBLL cmk, Iconfig_majorbBLL cm, Isalary_standardBLL ss)
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
        public IActionResult check_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult check_list(FenYeModel fen) 
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "check_status=0";
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
        [HttpGet]
        public IActionResult check(int id) 
        {
            major_changeModel hfm = mc.SelById(id);
            ViewBag.User_name = HttpContext.Session.GetString("User_name");
            ViewData.Model = hfm;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> check(int id, major_changeModel mcm) 
        {
            string firstname = HttpContext.Request.Form["configThird.firstKindId"];
            string senconname = HttpContext.Request.Form["name2"];
            string thirdname = HttpContext.Request.Form["name3"];
            string majorkname = HttpContext.Request.Form["sss"];
            string majj = HttpContext.Request.Form["sss2"];
            string saj = HttpContext.Request.Form["sss3"];
            string je = HttpContext.Request.Form["newsum"];
            string zt = Request.Form["check_status"];
            if (zt == "true")
            {
                List<config_file_first_kindModel1> list = icf.Selects().Where(e => e.first_kind_id == firstname).ToList();
                mcm.new_first_kind_id = list[0].first_kind_id;
                mcm.new_first_kind_name = list[0].first_kind_name;
                List<config_file_second_kindModel1> list1 = ics.Loads().Where(e => e.second_kind_id == senconname).ToList();
                mcm.new_second_kind_id = list1[0].second_kind_id;
                mcm.new_second_kind_name = list1[0].second_kind_name;
                List<config_file_third_kindModel1> list2 = ict.Selectt().Where(e => e.third_kind_id == thirdname).ToList();
                mcm.new_third_kind_id = list2[0].third_kind_id;
                mcm.new_third_kind_name = list2[0].third_kind_name;
                List<config_majorModel1> list3 = cm.Select().Where(e => e.major_kind_id == majorkname).ToList();
                mcm.new_major_kind_id = list3[0].major_kind_id;
                mcm.new_major_kind_name = list3[0].major_kind_name;
                List<config_majorModel1> list4 = cm.Select().Where(e => e.major_id == majj).ToList();
                mcm.new_major_id = list4[0].major_id;
                mcm.new_major_name = list4[0].major_name;
                List<salary_standardModel> list5 = ss.Select().Where(e => e.standard_name == saj).ToList();
                mcm.new_salary_standard_id = list5[0].standard_id;
                mcm.new_salary_standard_name = list5[0].standard_name;
                mcm.new_salary_sum = Convert.ToDouble(je);
                List<major_changeModel> list6 = mc.Sel();
                mcm.check_status = 1;
                mcm.mch_id = id;
                mcm.register = ViewBag.User_name;
                mcm.regist_time = DateTime.Now;

                if (await mc.Up(id,mcm) > 0)
                {
                    return RedirectToAction("check_success");
                    //return RedirectToAction("Index");
                }
                else
                {
                    //ViewData.Model = mcm;
                    //return RedirectToAction("register");
                    return Content("<script>alert('失败')</script>");
                }
            }
            else 
            {
                List<config_file_first_kindModel1> list = icf.Selects().Where(e => e.first_kind_id == firstname).ToList();
                mcm.new_first_kind_id = list[0].first_kind_id;
                mcm.new_first_kind_name = list[0].first_kind_name;
                List<config_file_second_kindModel1> list1 = ics.Loads().Where(e => e.second_kind_id == senconname).ToList();
                mcm.new_second_kind_id = list1[0].second_kind_id;
                mcm.new_second_kind_name = list1[0].second_kind_name;
                List<config_file_third_kindModel1> list2 = ict.Selectt().Where(e => e.third_kind_id == thirdname).ToList();
                mcm.new_third_kind_id = list2[0].third_kind_id;
                mcm.new_third_kind_name = list2[0].third_kind_name;
                List<config_majorModel1> list3 = cm.Select().Where(e => e.major_kind_id == majorkname).ToList();
                mcm.new_major_kind_id = list3[0].major_kind_id;
                mcm.new_major_kind_name = list3[0].major_kind_name;
                List<config_majorModel1> list4 = cm.Select().Where(e => e.major_id == majj).ToList();
                mcm.new_major_id = list4[0].major_id;
                mcm.new_major_name = list4[0].major_name;
                List<salary_standardModel> list5 = ss.Select().Where(e => e.standard_name == saj).ToList();
                mcm.new_salary_standard_id = list5[0].standard_id;
                mcm.new_salary_standard_name = list5[0].standard_name;
                mcm.new_salary_sum = Convert.ToDouble(je);
                List<major_changeModel> list6 = mc.Sel();
                mcm.mch_id = id;
                mcm.check_status = 2;

                mcm.register = ViewBag.User_name;
                mcm.regist_time = DateTime.Now;

                if (await mc.Up(id,mcm) > 0)
                {
                    return RedirectToAction("check_list");
                }
                else
                {
                    return Content("<script>alert('失败')</script>");
                }
            }       
        }
        //一级
        public ActionResult Index1()
        {
            List<config_file_first_kindModel1> list = icf.Selects();
            string a = JsonConvert.SerializeObject(list);
            SelectList si1 = new SelectList(list, "first_kind_id", "first_kind_name");
            ViewData["s1"] = si1;
            return Json(a);
        }
        //二级
        public ActionResult Index2(string id)
        {
            List<config_file_second_kindModel1> list = ics.Loads().Where(e => e.first_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            SelectList si2 = new SelectList(list, "second_kind_id", "second_kind_name");
            ViewData["s2"] = si2;
            return Json(a);
        }
        //三级
        public ActionResult ThiSecond(string id)
        {
            List<config_file_third_kindModel1> list = ict.Selectt().Where(e => e.second_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            SelectList si3 = new SelectList(list, "third_kind_id", "third_kind_name");
            ViewData["s3"] = si3;
            return Json(a);
        }
        //新职业分类
        public ActionResult Index4()
        {
            List<config_major_kindModel1> list = cmk.Select().ToList();
            string a = JsonConvert.SerializeObject(list);
            SelectList si4 = new SelectList(list, "major_kind_id", "major_kind_name");
            ViewData["s4"] = si4;
            return Json(a);
        }
        //新职位名称
        public ActionResult Index5(string id)
        {
            List<config_majorModel1> list = cm.Select().Where(e => e.major_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            SelectList si5 = new SelectList(list, "major_id", "major_name");
            ViewData["s5"] = si5;
            return Json(a);
        }
        //薪酬标准
        public ActionResult Index6()
        {
            List<salary_standardModel> list = ss.Select().ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //薪酬总额
        public IActionResult NSum(string id)
        {
            List<salary_standardModel> list = ss.Select().Where(e => e.check_status == 0 & e.standard_name == id).ToList();
            return Json(list[0].salary_sum);
        }
        public IActionResult check_success() 
        {
            return View();
        }
    }
}

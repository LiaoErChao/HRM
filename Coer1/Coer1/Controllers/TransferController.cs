using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IDAO;
using IBLL;
using Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Coer1.Controllers
{
    public class TransferController : Controller
    {
        private readonly Iconfig_file_first_kindBLL icf;
        private readonly Iconfig_file_second_kindBLL ics;
        private readonly Iconfig_file_third_kindBLL ict;
        private readonly Ihuman_fileBLL hum;
        private readonly Imajor_changeBLL mc;
        private readonly Iconfig_majorbBLL cm;
        private readonly Iconfig_major_kindBLL cmk;
        private readonly Isalary_standardBLL ss;

        public TransferController(Iconfig_file_first_kindBLL cof,Iconfig_file_second_kindBLL cos,Iconfig_file_third_kindBLL cot,Ihuman_fileBLL hum,Imajor_changeBLL mc, Iconfig_major_kindBLL cmk,Iconfig_majorbBLL cm,Isalary_standardBLL ss) 
        {
            this.icf = cof;
            this.ics = cos;
            this.ict = cot;
            this.hum = hum;
            this.mc = mc;
            this.cmk = cmk;
            this.cm = cm;
            this.ss=ss;
        }
        [HttpGet]
        public async Task<IActionResult> register_locate()
        {
            List<config_file_first_kindModel> list = await icf.SelectAll();
            SelectList ss = new SelectList(list, "first_kind_name", "first_kind_name");
            ViewData["first"] = ss;
            return View();
        }
        //一级
        public ActionResult Index1()
        {
            List<config_file_first_kindModel> list = icf.Selects();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //二级
        public ActionResult Index2(string id)
        {
            List<config_file_second_kindModel> list = ics.Loads().Where(e => e.first_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //三级
        public ActionResult ThiSecond(string id)
        {
            List<config_file_third_kindModel> list = ict.Selectt().Where(e => e.second_kind_id == id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //新职业分类
        public ActionResult Index4() 
        {
            List<config_major_kindModel> list = cmk.Select().ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //新职位名称
        public ActionResult Index5(string id) 
        {
            List<config_majorModel> list = cm.Select().Where(e=>e.major_kind_id==id).ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        //薪酬标准
        public ActionResult Index6() 
        {
            List<salary_standardModel> list = ss.Select().ToList();
            string a = JsonConvert.SerializeObject(list);
            return Json(a);
        }
        [HttpPost]
        public IActionResult register_locate(config_file_third_kindModel a) 
        {

            HttpContext.Session.SetString("yiji", Request.Form["emajorRelease.firstKindId"]);
            HttpContext.Session.SetString("erji", Request.Form["emajorRelease.secondKindId"]);
            HttpContext.Session.SetString("sanji", Request.Form["emajorRelease.thirdKindId"]);
            HttpContext.Session.SetString("sj1", Request.Form["utilbean.startDate"]);
            HttpContext.Session.SetString("sj2", Request.Form["utilbean.endDate"]);
           
            return Redirect("/Transfer/register_list");
            //if (a.third_kind_name == null)
            //{
            //    a.third_kind_name = HttpContext.Session.GetString("aabb");
            //    return Content("<script>alert('请选择三级机构');window.location.href='/Transfer/register_locate'</script>");
            //}
            //else
            //{
            //    return Content("<script>window.location.href='/Transfer/register_list'</script>");
            //}
        }
        //调动登记列表
        [HttpGet]
        public IActionResult register_list() 
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult register_list(FenYeModel fen) {
            string currentPage = Request.Form["currentPage"];

            string yiji = HttpContext.Session.GetString("yiji");
            string erji = HttpContext.Session.GetString("erji");
            string sanji = HttpContext.Session.GetString("sanji");
            string sj1 = HttpContext.Session.GetString("sj1");
            string sj2 = HttpContext.Session.GetString("sj2");

            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = $@" first_kind_id='{yiji}' and second_kind_id='{erji}' and third_kind_id='{sanji}' and regist_time>='{sj1}' and regist_time<='{sj2}'";
            fen.KeyName = "huf_id";
            fen.TableName = "human_file";
            List<human_fileModel> page = hum.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpGet]
        public IActionResult register(int id) 
        {
            human_fileModel hfm = hum.SelByID02(id);
            ViewBag.User_name = HttpContext.Session.GetString("User_name");

            major_changeModel mcm = new major_changeModel()
            {
                first_kind_id = hfm.first_kind_id,
                first_kind_name = hfm.first_kind_name,
                second_kind_id = hfm.second_kind_id,
                second_kind_name = hfm.second_kind_name,
                third_kind_id = hfm.third_kind_id,
                third_kind_name = hfm.third_kind_name,
                major_id = hfm.human_major_id,
                major_name = hfm.hunma_major_name,
                major_kind_id = hfm.human_major_kind_id,
                major_kind_name = hfm.human_major_kind_name,
                human_id = hfm.human_id,
                human_name = hfm.human_name,
                salary_standard_id = hfm.salary_standard_id,
                salary_standard_name = hfm.salary_standard_name,
                salary_sum = hfm.salary_sum,
                regist_time = DateTime.Now,
                register = HttpContext.Session.GetString("User_name")

            };
            //1
            List<config_file_first_kindModel> list = icf.Selects();
            List<config_file_first_kindModel> lis = icf.Selects().Where(e => e.first_kind_name == mcm.first_kind_name).ToList();
            for (int i = 0; i < lis.Count; i++)
            {
                if (list[i].first_kind_name == lis[0].first_kind_name)
                {
                    list.Remove(list[i]);
                    break;
                }
            }

            List<config_major_kindModel> list3 = cmk.Select();
            List<config_major_kindModel> lis4 = cmk.Select().Where(e => e.major_kind_id == mcm.major_kind_id).ToList();
            for (int i = 0; i < list3.Count; i++)
            {
                if (list3[i].major_kind_id == lis4[0].major_kind_id)
                {
                    list3.Remove(list3[i]);
                    break;
                }
            }

            List<salary_standardModel> list5 = ss.Select().Where(e => e.check_status == 1).ToList();

            SelectList sl = new SelectList(list, "first_kind_name", "first_kind_name", "请选择");
            SelectList sl3 = new SelectList(list3, "major_kind_name", "major_kind_name", "请选择");
            SelectList sl5 = new SelectList(list5, "standard_name", "standard_name", "请选择");
            ViewData["majork"] = sl3;
            ViewData["standard"] = sl5;
            ViewData["first"] = sl;
            ViewData.Model = mcm;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register(major_changeModel mcm)
        {
            string firstname = HttpContext.Request.Form["configThird.firstKindId"];
            string senconname = HttpContext.Request.Form["name2"];
            string thirdname = HttpContext.Request.Form["name3"];
            string majorkname = HttpContext.Request.Form["sss"];
            string majj = HttpContext.Request.Form["sss2"];
            string saj = HttpContext.Request.Form["sss3"];
            string je = HttpContext.Request.Form["newsum"];
            List<config_file_first_kindModel> list = icf.Selects().Where(e => e.first_kind_id == firstname).ToList();
            mcm.new_first_kind_id = list[0].first_kind_id;
            mcm.new_first_kind_name = list[0].first_kind_name;
            List<config_file_second_kindModel> list1 = ics.Loads().Where(e => e.second_kind_id == senconname).ToList();
            mcm.new_second_kind_id = list1[0].second_kind_id;
            mcm.new_second_kind_name = list1[0].second_kind_name;
            List<config_file_third_kindModel> list2 = ict.Selectt().Where(e => e.third_kind_id == thirdname).ToList();
            mcm.new_third_kind_id = list2[0].third_kind_id;
            mcm.new_third_kind_name = list2[0].third_kind_name;
            List<config_majorModel> list3 = cm.Select().Where(e => e.major_kind_id == majorkname).ToList();
            mcm.new_major_kind_id = list3[0].major_kind_id;
            mcm.new_major_kind_name = list3[0].major_kind_name;
            List<config_majorModel> list4 = cm.Select().Where(e => e.major_id == majj).ToList();
            mcm.new_major_id = list4[0].major_id;
            mcm.new_major_name = list4[0].major_name;
            List<salary_standardModel> list5 = ss.Select().Where(e => e.standard_name == saj).ToList();
            mcm.new_salary_standard_id = list5[0].standard_id;
            mcm.new_salary_standard_name = list5[0].standard_name;
            mcm.new_salary_sum = Convert.ToDouble(je);

            mcm.register = ViewBag.User_name;
            mcm.regist_time = DateTime.Now;

            if (await mc.Ad(mcm) > 0)
            {
                return Redirect("/Transfer/register_success");
                    //return RedirectToAction("Index");
            }
            else
             {
                    //ViewData.Model = mcm;
                    //return RedirectToAction("register");
                return Content("<script>alert('失败')</script>");
            }
        }
        public ActionResult register_success()
        {
            return View();
        }
        public IActionResult NSum(string id)
        {
            List<salary_standardModel> list = ss.Select().Where(e => e.check_status == 0 & e.standard_name == id).ToList();
            return Json(list[0].salary_sum);
        }
    }

}

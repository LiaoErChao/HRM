using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis;

namespace Coer1.Controllers
{
    public class salaryGrantController : Controller
    {

        private readonly Ihuman_fileBLL ihfb;
        private readonly Isalary_standard_detailsBLL issdb;
        public salaryGrantController(Ihuman_fileBLL ihfb, Isalary_standard_detailsBLL issdb) {
            this.ihfb = ihfb;
            this.issdb = issdb;
        }
        public IActionResult register_locate()
        {
            return View();
        }

        #region 一二三级机构
        public IActionResult cha()
        {
            string id = HttpContext.Request.Form["submitType"];
            HttpContext.Session.SetString("id", id);
            return View("register_list");
        }
        [HttpGet]
        public  IActionResult register_list() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> register_list1() {
            string id = HttpContext.Session.GetString("id");
           
            List<human_fileModel1> sgm =await ihfb.Select();
            List<human_fileModel1> list = new List<human_fileModel1>();
            Dictionary<string, object> di = new Dictionary<string, object>();
            string jg = "";
            if (id == "1")
            {
                jg = "一级机构名称";
                list = sgm.Where(e => e.first_kind_id != null &&e.first_kind_name!=null &&e.check_status == 1).ToList();
                var z = list.GroupBy(g => new { g.first_kind_id, g.first_kind_name }).Select(g => (new { fstid = g.Key.first_kind_id, fstname = g.Key.first_kind_name, count = g.Count(), salasum = g.Sum(item => item.salary_sum) })).ToList();
                di["dt"] = z;
                di["index"] = z.Count;
            }
            else if(id=="2"){
                jg = "二级机构名称";
                list = sgm.Where(e => e.second_kind_id != null &&e.second_kind_name!=null && e.check_status == 1).ToList();               
                var z = list.GroupBy(g => new { g.second_kind_id, g.second_kind_name }).Select(g => (new { fstid = g.Key.second_kind_id, fstname = g.Key.second_kind_name, count = g.Count(), salasum = g.Sum(item => item.salary_sum) })).ToList();
                di["dt"] = z;//数据`
                di["index"] = z.Count; //薪酬总数
            }
            else if (id == "3")
            {
                jg = "三级机构名称";
                list = sgm.Where(e => e.third_kind_id != null &&e.third_kind_name!=null &&e.check_status == 1).ToList();             
                var z = list.GroupBy(g => new { g.third_kind_id, g.third_kind_name }).Select(g => (new { fstid = g.Key.third_kind_id, fstname = g.Key.third_kind_name, count = g.Count(), salasum = g.Sum(item => item.salary_sum) })).ToList();
                di["dt"] = z;
                di["index"] = z.Count;
            }
            di["salary_sum"] = list.Sum(g => g.salary_sum);//基本薪酬总数
            di["paid_sum"] = list.Sum(g => g.paid_salary_sum);//实发总额       
            di["rows"] = list.Count();//总人数
            di["jg"] = jg;
            return Content(JsonConvert.SerializeObject(di));

        }

        #endregion
        #region 机构查询
        [HttpGet]
        public IActionResult register_commit(string fstname) {

            string fstname1 = fstname;
            HttpContext.Session.SetString("fstname", fstname1);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> register_commit() {
            string fstname = HttpContext.Session.GetString("fstname");
            string id = HttpContext.Session.GetString("id");
            Dictionary<string, object> di = new Dictionary<string, object>();
            List<human_fileModel1> hfm =await ihfb.Select();
            List<human_fileModel1> list = new List<human_fileModel1>();
            if (id == "1") {
                list = hfm.Where(e => e.first_kind_name == fstname && e.check_status == 1).ToList();
            } else if (id == "2") {
                list = hfm.Where(e => e.second_kind_name == fstname && e.check_status == 1).ToList();
            }
            else if (id == "3")
            {
                list = hfm.Where(e => e.third_kind_name == fstname && e.check_status == 1).ToList();
            }
            di["salary_standard_id"] = list[0].salary_standard_id;
            di["dt"] = list;
            di["paid_sum"]= list.Sum(g => g.paid_salary_sum);//实发薪酬总额
            di["salary_sum"] = list.Sum(g=>g.salary_sum);//基本薪酬总额
            di["conten"] = list.Count();
            di["fstname"] = fstname;
            di["uname"] = HttpContext.Session.GetString("Uname");
            return Content(JsonConvert.SerializeObject(di));
        }
        #endregion
        #region 模态框
        public IActionResult Select(string id) {     
            
            List<salary_standard_detailsModel> list = issdb.Select().Where(e => e.standard_id == id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        #endregion
        #region 提交

        public async Task<IActionResult> Upd()
        {
            string[] huf_id = Request.Form["huf_id"];
            string[] paid_salary_sum = Request.Form["grantDetails[0].salaryPaidSum"];//实发金额 
            string register = Request.Form["salaryGrant.register"];
            int result = 0;
            for (int i = 0; i < huf_id.Length; i++)
            {
                human_fileModel1 hfm = new human_fileModel1()
                {
                    huf_id = int.Parse(huf_id[i]),
                    paid_salary_sum = double.Parse(paid_salary_sum[i]),
                    salary_sum = double.Parse(paid_salary_sum[i]),
                    register = register,
                    check_status = 2,
                    regist_time = DateTime.Now.ToLocalTime()
                };
               result= await ihfb.Denji(hfm);
            }
            if (result > 0)
            {
                return RedirectToAction("register_success");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult register_success() {

            return View();
        }

        #endregion


        #region 薪酬发放登记复核
        public IActionResult check_list() {
          return  View();
        }
        public IActionResult load(int id) {

            DBFenYe<human_fileModel1> li = ihfb.Fenye(id, "human_file", "check_status=2", "huf_id", 3);

            return Content(JsonConvert.SerializeObject(li));           
        }
        #endregion
        #region 复核
        public IActionResult check(string id,int huf_id)
        {


            HttpContext.Session.SetInt32("huf_id", huf_id);
            HttpContext.Session.SetString("sid", id);

            return View();
        }

        public async Task<IActionResult> check_load() {
            string huf_id = HttpContext.Session.GetString("sid");

           
            List<human_fileModel1> sgm = await ihfb.Select();
            List<human_fileModel1> list = new List<human_fileModel1>();
            Dictionary<string, object> di = new Dictionary<string, object>();
            list = sgm.Where(e => e.salary_standard_id == huf_id && e.check_status == 2).ToList();
            di["list"] = list;
            di["Conte"] = list.Count();
            di["sum"] = list.Sum(g => g.salary_sum);
            di["Uname"] = HttpContext.Session.GetString("Uname");
            di["sid"] = huf_id;
            return Content(JsonConvert.SerializeObject(di));
        }

        public async Task<IActionResult> Update()
        {
            string[] huf_id = Request.Form["huf_id"];//主键
            string[] paid_salary_sum = Request.Form["grantDetails[0].salaryPaidSum"];//实发金额 
            string register = Request.Form["salaryGrant.checker"];//复核人
          
            int result = 0;
            for (int i = 0; i < huf_id.Length; i++)
            {
                human_fileModel1 hfm = new human_fileModel1()
                {
                    huf_id = int.Parse(huf_id[i]),
                    paid_salary_sum = double.Parse(paid_salary_sum[i]),
                    salary_sum = double.Parse(paid_salary_sum[i]),
                    register = register,
                    check_status = 3,
                    check_time = DateTime.Now.ToLocalTime()
            };
                result = await ihfb.Update(hfm);
            }
            if (result > 0)
            {
                return RedirectToAction("check_success");
            }
            else
            {
                return View();
            }

        }

        public IActionResult check_success() {
            return View();
        }
        #endregion
        #region 薪酬发放查询

        public IActionResult query_locate() {

            return View();
        }

        public IActionResult query_list() {
            string sid = Request.Form["salaryGrant.salaryGrantId"];
            string gjz = Request.Form["utilbean.primarKey"];
            string rq1 = Request.Form["utilbean.startDate"];
            string re2 = Request.Form["utilbean.endDate"];
           
            HttpContext.Session.SetString("xcdh",sid);
            HttpContext.Session.SetString("gjz", gjz);
            HttpContext.Session.SetString("rq1", rq1);
            HttpContext.Session.SetString("rq2", re2);
            return View();
        }

        public IActionResult XinChou(int currentPage) {

           string aa= HttpContext.Session.GetString("rq1");
           string bb= HttpContext.Session.GetString("rq2");

            string sid = HttpContext.Session.GetString("xcdh");
            string gjz = HttpContext.Session.GetString("gjz");
            string where =  $@" salary_standard_id = '{sid}' or human_name like '%{gjz}%' and check_time >= '{aa}'and check_time<='{bb}' and check_status=3";
            DBFenYe<human_fileModel1> li = ihfb.Fenye(currentPage, "human_file", where, "huf_id", 3);

            return Content(JsonConvert.SerializeObject(li));
        }


        public IActionResult query(string id) {
            string aa = id;
            HttpContext.Session.SetString("awd",aa);
            return View();
        }
        public async Task<IActionResult> query1()
        {
            string id = HttpContext.Session.GetString("awd");
            List<human_fileModel1> hfm = await ihfb.Select();
            List<human_fileModel1> list = new List<human_fileModel1>();
            Dictionary<string, object> di = new Dictionary<string, object>();
            list = hfm.Where(e=>e.salary_standard_id==id).ToList();
            string djsj = "";
            string djr = "";
            string xcbh = "";
            for (int i = 0; i < list.Count; i++)
            {
                djsj = list[i].regist_time.ToString();
                djr = list[i].register;
                xcbh = list[i].salary_standard_id;
            }
            di["list"] = list;
            di["djsj"] = djsj;
            di["djr"] = djr;
            di["id"] = id;
            di["salary_sum"] = list.Sum(e => e.salary_sum);
            di["paid_salary_sum"] = list.Sum(e => e.paid_salary_sum);
            di["Count"] = list.Count();
            return Content(JsonConvert.SerializeObject(di));
        }
        #endregion
    }
}
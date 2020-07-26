using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFEntity;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Model;
using Newtonsoft.Json;

namespace Coer1.Controllers
{
    public class SalaryStandardController : Controller
    {
        TescDbContext tescDbContext = new TescDbContext();

        private Isalary_standardBLL issb;
        private Isalary_standard_detailsBLL issdb;
        public SalaryStandardController(Isalary_standardBLL issb, Isalary_standard_detailsBLL issdb)
        {
            this.issb = issb;
            this.issdb = issdb;
        }

        [HttpGet]
        //单号生成
        public IActionResult register()
        {
            string str = "";
            var liststandard_id = (from salary_standard in tescDbContext.ss
                                   orderby salary_standard.standard_id
                                   select salary_standard).ToList();
            if (liststandard_id.Count > 0)
            {
                int count = liststandard_id.Count;
                salary_standard sst = liststandard_id[count - 1];
                int intcod = Convert.ToInt32(sst.standard_id.Substring(2, 10));
                intcod++;
                str = intcod.ToString();
                for (int i = 0; i < 10; i++)
                {
                    str = str.Length < 10 ? "0" + str : str;
                }
                str = "HR" + str;
            }
            else
            {
                str = "HR0000000001";
            }
            ViewBag.s = str;
            string a = HttpContext.Session.GetString("Uname");
            ViewBag.aa = a;
            return View();
        }

        //添加 
        public async Task<IActionResult> register_Add(salary_standardModel1 ssm)
        {

            if (ModelState.IsValid)
            {
                string[] item_id = HttpContext.Request.Form["details.itemId"];
                string[] item_name = HttpContext.Request.Form["details.itemName"];
                string[] salary = HttpContext.Request.Form["details.salary"];

                int result = await issb.salary_standardAdd(ssm);
                if (result > 0)
                {
                    for (int i = 0; i < item_id.Length; i++)
                    {
                        salary_standard_detailsModel ssdm = new salary_standard_detailsModel()
                        {
                            item_id = int.Parse(item_id[i].ToString()),
                            item_name = item_name[i].ToString(),
                            salary = double.Parse(salary[i].ToString()),
                            standard_id = ssm.standard_id,
                            standard_name = ssm.standard_name
                        };

                        int result2 = await issdb.salary_standard_detailsAdd(ssdm);
                    }
                }
                return View("register_success");
            }
            else
            {
                return View(ssm);
            }
        }
        //操作成功
        public IActionResult register_success()
        {
            return View();
        }

        //分页查询
        [HttpGet]
        public IActionResult check_list()
        {
            return View();
        }
        [HttpPost]
        public ActionResult check_list(int id)
        {

            //(int dqy, string tablename, string where, string keyname, int pagesize)
            DBFenYe<salary_standardModel1> li = issb.Fenye(id, "salary_standard", "check_status=0", "ssd_id", 3);

            return Content(JsonConvert.SerializeObject(li));

        }

        //复核
        public ActionResult check(string id)
        {


            //string id = Request["id"];
            List<salary_standardModel1> list = issb.Select().Where(e => e.standard_id == id).ToList();
            List<salary_standard_detailsModel> list2 = issdb.Select().Where(e => e.standard_id == id).ToList();
            ViewTable vt = new ViewTable()
            {
                salary_standardModel = list,
                salary_standard_detailsModel = list2
            };
            ViewBag.a = HttpContext.Session.GetString("Uname");


            return View(vt);

        }

        //复核修改

        public async Task<IActionResult> Update(salary_standardModel1 ssm)
        {

            string[] sdt_id = HttpContext.Request.Form["sdt_id"];
            string[] item_name = HttpContext.Request.Form["item_name"];
            string[] salary = HttpContext.Request.Form["salary"];
            string ssid = HttpContext.Request.Form["ssid"];
            ssm.ssd_id = int.Parse(ssid);
            int result = await issb.Update(ssm);
            if (result > 0)
            {

                for (int i = 0; i < sdt_id.Length; i++)
                {
                    salary_standard_detailsModel ssdm = new salary_standard_detailsModel()
                    {
                        standard_id = ssm.standard_id,
                        standard_name = ssm.standard_name,
                        sdt_id = int.Parse(sdt_id[i]),
                        item_name = item_name[i],
                        salary = double.Parse(salary[i])
                    };
                    await issdb.Update(ssdm);
                }
                return RedirectToAction("check_success");
            }
            else
            {
                List<salary_standardModel1> list = issb.Select().Where(e => e.standard_id == ssm.standard_id).ToList();
                List<salary_standard_detailsModel> list2 = issdb.Select().Where(e => e.standard_id == ssm.standard_id).ToList();
                ViewTable vt = new ViewTable()
                {
                    salary_standardModel = list,
                    salary_standard_detailsModel = list2
                };
                return View(vt);
            }

        }

        //复核成功

        public IActionResult check_success()
        {
            return View();
        }


        //薪酬标准查询

        public IActionResult query_locate()
        {
            return View();
        }
        public IActionResult Select()
        {

            HttpContext.Session.SetString("standard_id", HttpContext.Request.Form["standard_id"]);
            HttpContext.Session.SetString("standard_name", HttpContext.Request.Form["standard_name"]);
            HttpContext.Session.SetString("regist_time1", HttpContext.Request.Form["utilbean.startDate"]);
            HttpContext.Session.SetString("regist_time2", HttpContext.Request.Form["utilbean.endDate"]);
            return RedirectToAction("query_list");
        }

        [HttpGet]
        public IActionResult query_list()
        {

            return View();
        }
        [HttpPost]
        public IActionResult query_list(int currenPage)
        {
            string standard_id = HttpContext.Session.GetString("standard_id");
            string name = HttpContext.Session.GetString("standard_name");

            string time1 = HttpContext.Session.GetString("regist_time1");
            string time2 = HttpContext.Session.GetString("regist_time2");

          

            string where = $@" standard_id='{standard_id}' or standard_name like '%{name}%' or regist_time>='{time1}' and regist_time<='{time2}'";
            DBFenYe<salary_standardModel1> li = issb.Fenye(currenPage, "salary_standard", where, "ssd_id", 3);

            return Content(JsonConvert.SerializeObject(li));

        }
        //薪酬标准查询


        //打印的开始

        public IActionResult query(string id)
        {

            List<salary_standardModel1> list = issb.Select().Where(e => e.standard_id == id).ToList();
            List<salary_standard_detailsModel> list2 = issdb.Select().Where(e => e.standard_id == id).ToList();
            ViewTable vt = new ViewTable()
            {
                salary_standardModel = list,
                salary_standard_detailsModel = list2
            };
            ViewBag.a = HttpContext.Session.GetString("Uname");


            return View(vt);
        }
        public ActionResult Dayin()
        {

            string standard_id = HttpContext.Request.Form["standard_id"];
            string standard_name = HttpContext.Request.Form["standard_name"];
            string salary_sum = HttpContext.Request.Form["salary_sum"];
            string designer = HttpContext.Request.Form["designer"];
            string checker = HttpContext.Request.Form["checker"];
            string check_time = HttpContext.Request.Form["check_time"];
            string remark = HttpContext.Request.Form["remark"];
            string[] sdt_id = HttpContext.Request.Form["sdt_id"];
            string[] item_name = HttpContext.Request.Form["item_name"];
            string[] salary = HttpContext.Request.Form["salary"];

            FileStream fs = new FileStream(@"D:/dayin.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //Writer fw = new FileWriter(file, true);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write("\t\t" + "薪酬信息打印");
                sw.Write("\r\n" + "---------------------------------------------------------");
                sw.Write("\r\n" + "薪酬编号:" + "\t\t" + standard_id);
                sw.Write("\r\n" + "薪酬标准单名称:" + "\t\t" + standard_name);
                sw.Write("\r\n" + "薪酬总额:" + "\t\t" + salary_sum);
                sw.Write("\r\n" + "制定者名字:" + "\t\t" + designer);
                sw.Write("\r\n" + "复核人:" + "\t\t\t" + checker);
                sw.Write("\r\n" + "复核时间:" + "\t\t" + check_time);
                sw.Write("\r\n" + "备注:" + "\t\t" + remark);
                sw.Write("\r\n" + "---------------------------------------------------------");
                for (int i = 0; i < sdt_id.Length; i++)
                {
                    sw.Write("\r\n" + sdt_id[i] + "\t\t" + item_name[i] + "\t\t" + salary[i]);
                }
                sw.Flush();
                sw.Close();
                sw.Close();
            }
            return Content("<script>alert('打印成功');window,location.href='/Query/locate';</script>");
        }
        //打印结束


        //薪酬标准变更 
        public ActionResult change_locate() {
            return View();
        }
        public ActionResult tiao() {
            string standard_id= HttpContext.Request.Form["standard_id1"];
            string standard_name = HttpContext.Request.Form["standard_name1"];
            string regist_time1 = HttpContext.Request.Form["utilbean.startDate"];
            string regist_time2 = HttpContext.Request.Form["utilbean.endDate"];

            HttpContext.Session.SetString("standard_id1", standard_id);
            HttpContext.Session.SetString("standard_name1", standard_name);
            HttpContext.Session.SetString("regist_time12", regist_time1);
            HttpContext.Session.SetString("regist_time22", regist_time2);
            return RedirectToAction("change_list");
        }


        [HttpGet]
        public ActionResult change_list() {
            return View();
        }
        [HttpPost]
        public ActionResult change_list(int currenPage) {

            string standard_id = HttpContext.Session.GetString("standard_id1");
            string name = HttpContext.Session.GetString("standard_name1");

            string time1 = HttpContext.Session.GetString("regist_time12");
            string time2 = HttpContext.Session.GetString("regist_time22");

            

            string where = $@" standard_id='{standard_id}' or standard_name like '%{name}%' or regist_time>='{time1}' and regist_time<='{time2}' and change_status=0";
            DBFenYe<salary_standardModel1> li = issb.Fenye(currenPage, "salary_standard", where, "ssd_id", 3);

            return Content(JsonConvert.SerializeObject(li));
        }

        //变更
        public IActionResult change(string id) {
            List<salary_standardModel1> list = issb.Select().Where(e => e.standard_id == id).ToList();
            List<salary_standard_detailsModel> list2 = issdb.Select().Where(e => e.standard_id == id).ToList();
            ViewTable vt = new ViewTable()
            {
                salary_standardModel = list,
                salary_standard_detailsModel = list2
            };
            ViewBag.b = HttpContext.Session.GetString("Uname");


            return View(vt);
        }

        public async Task<IActionResult> Upd(salary_standardModel1 ssm)
        {
            string[] sdt_id = HttpContext.Request.Form["sdt_id"];
            string[] item_name = HttpContext.Request.Form["item_name"];
            string[] salary = HttpContext.Request.Form["salary"];
            string ssid = HttpContext.Request.Form["ssid"];
            ssm.ssd_id = int.Parse(ssid);
            int result = await issb.Upd(ssm);
            if (result > 0)
            {
                for (int i = 0; i < sdt_id.Length; i++)
                {
                    salary_standard_detailsModel ssdm = new salary_standard_detailsModel()
                    {
                        standard_id = ssm.standard_id,
                        standard_name = ssm.standard_name,
                        sdt_id = int.Parse(sdt_id[i]),
                        item_name = item_name[i],
                        salary = double.Parse(salary[i])
                    };
                    await issdb.Update(ssdm);

                }
                return RedirectToAction("change_success");

            }
            else {
                return RedirectToAction("change_success");

            }

        }

        //变更成功
        public IActionResult change_success()
        {
           return View();
        }
    }
}
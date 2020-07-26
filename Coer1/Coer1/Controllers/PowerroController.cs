using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using EFEntity;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Newtonsoft.Json;

namespace Coer1.Controllers
{
    public class PowerroController : Controller
    {
        private readonly IroleBLL irb;
        private readonly TescDbContext1 tesc;
        public PowerroController(IroleBLL irb,TescDbContext1 tesc) 
        {
            this.irb = irb;
            this.tesc = tesc;
        }
        [HttpGet]
        public IActionResult right_list()
        {
            return View();
        }
        [HttpPost]
        public IActionResult right_list(FenYeModel fen) 
        {
            string currentPage = Request.Form["currentPage"];
            fen.CurrentPage = int.Parse(currentPage.ToString());
            fen.PageSize = 3;
            fen.Where = "";
            fen.KeyName = "r_id";
            fen.TableName = "role";
            List<roleModel> page = irb.FenYe(fen);
            Dictionary<string, object> di = new Dictionary<string, object>();
            di["dt"] = page;
            di["pages"] = fen.Pages;
            di["rows"] = fen.Rows;
            di["PageSize"] = fen.PageSize;
            return Content(JsonConvert.SerializeObject(di));
        }
        public IActionResult right_add() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> right_adds() 
        {
            string JSMC = HttpContext.Request.Form["sysRole.roleName"];
            string SFKY = HttpContext.Request.Form["sysRole.roleFlag"];
            string SM = HttpContext.Request.Form["sysRole.roleDesc"];
            roleModel a = new roleModel() 
            {
                user_identity = JSMC,
                r_status = Convert.ToInt32(SFKY),
                r_sm=SM
            };
            if (ModelState.IsValid)
            {
                if (await irb.ADD(a) > 0)
                {
                    return RedirectToAction("right_list");
                }
                else
                {
                    return RedirectToAction("right_add");
                }
            }
            else
            {
                return RedirectToAction("right_add");
            }
        }
        public async Task<IActionResult> Del(int id)
        {
            if (await irb.Delete(id) > 0)
            {

                return RedirectToAction("right_list");
            }
            else
            {
                return RedirectToAction("right_list");
            }
        }
        public IActionResult xl(int? id)
        {
            string aa = HttpContext.Session.GetString("Tj");
            string sql = "";
            if (id == null)
            {
                sql = $@"select q.[id],[text],[state],Pid,[QuanURL],checked=
case 
when qr.Jid is null then 0
else 1
end
from dbo.Quan
        q
left join(
select Jid
from  dbo.Quanjs
where Qid={aa}
) qr on q.id=qr.Jid
where q.Pid=0
";
            }
            else
            {
                sql = $@"select q.[id],[text],[state],Pid,[QuanURL],checked=
case 
when qr.Jid is null then 0
else 1
end
from dbo.Quan
        q
left join(
select Jid
from  dbo.Quanjs
where Qid={aa}
) qr on q.id=qr.Jid
where q.Pid={id}
";
            }
            List<Qx> list = tesc.Qxes.FromSqlRaw(sql).ToList();
            return Ok(list);
        }
        public async Task<IActionResult> right_list_information(int id) 
        {
            HttpContext.Session.SetString("Tj", id.ToString());
            roleModel Lb = await irb.Select(id);
            ViewData.Model = Lb;          
            return View();
        }
     

        public async Task<IActionResult> XG(string dt,string bh,string sm,string zt)
        {

            
            String[] arr = dt.Split(",");
            string sql = $@"delete dbo.Quanjs where Qid={HttpContext.Session.GetString("Tj")}";
            int aa = tesc.Database.ExecuteSqlCommand(sql);
            int a = 0;
            roleModel r = new roleModel()
            {
                r_id=int.Parse(bh),
                r_sm=sm,
                r_status=int.Parse(zt)
            };
           int result= await irb.Update(r);         
            string sql1 = "";
            for (int i = 0; i < arr.Length; i++)
            {
                sql1 = $@"insert into dbo.Quanjs VALUES({HttpContext.Session.GetString("Tj")},{arr[i]})";
                a = tesc.Database.ExecuteSqlCommand(sql1);
            }
            if (a > 0)
            {
                return Ok(a);
            }
            else
            {
                return Ok(a);
            }
        }
    }
}

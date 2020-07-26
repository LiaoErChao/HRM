using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using EFEntity;
using Microsoft.EntityFrameworkCore;

namespace Coer1.Controllers
{
    public class MainController : Controller
    {
        private readonly IusersBLL iub;
        private readonly TescDbContext tesc;

        public MainController(IusersBLL iub, TescDbContext tesc) {
            this.tesc = tesc;
        
        
        }

        public IActionResult index()
        {
            return View();
        }
        public IActionResult left()
        {
            return View();
        }
        public IActionResult Top()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Quan(int? id) 
        {
            string aa = HttpContext.Session.GetString("Qid");
            string sql = "";
            if (id == null)
            {
                sql = $@"select q.id,[text],QuanURL,[state],Pid from dbo.Quan q inner join dbo.Quanjs qr on q.id=qr.Jid
where qr.Qid={aa} and q.Pid=0";

            }
            else
            {
                sql = $@"select q.id,[text],QuanURL,[state],Pid from dbo.Quan q inner join dbo.Quanjs qr on q.id=qr.Jid
where qr.Qid={aa} and q.Pid={id}";
            }
            //增删改sql myDbContext.Database.ExecuteSqlCommand()

            List<Quan> list = tesc.Quans.FromSqlRaw(sql).ToList();
            return Ok(list);
        }
    }
}

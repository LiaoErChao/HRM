using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFEntity;
using Model;
using IBLL;
using Newtonsoft.Json;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Iconfig_public_charBLL1 icpcb;
        public HomeController(Iconfig_public_charBLL1 icpcb) {
            this.icpcb = icpcb;
        }


        [HttpGet]
        //查询所有
        public async Task<IActionResult> config_public_chars() {

            List<config_public_charModel1> list2 = await icpcb.SelectAll();
            string zhi = JsonConvert.SerializeObject(list2);

            return Content(zhi);

        }


        [HttpPost]
        //添加
        public async Task<int> config_public_charAdd([FromQuery]string id,string name) {
            config_public_charModel1 cpc = new config_public_charModel1()
            {
                attribute_kind=id,
                attribute_name=name
            };
            int result = await icpcb.Add(cpc);

            return result;
        }

       


        [HttpDelete]
        //[Route("{id}")]
        //删除
        public async Task<int> config_public_charsc([FromQuery]int Sid)
        {
            int result  = await icpcb.Delete(Sid);
            return result;
            
        }


    }
}
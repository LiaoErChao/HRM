using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
using EFEntity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly Iconfig_majorbBLL icmb;

        public MajorController(Iconfig_majorbBLL icmb) {
            this.icmb = icmb;
        }

        [HttpGet]
        public async Task<IActionResult> config_majorLoad() {
            List<config_majorModel> list = await icmb.Load();
            return Content(JsonConvert.SerializeObject(list));
        
        }
        [HttpDelete]
        public async Task<int> config_majorLoadDel([FromQuery]int  id) {
            int result =await icmb.Delete(id);

            return result;
        }

        [HttpPost]

        public async Task<int> config_majorAdd([FromQuery]string major_kind_id,string majorkindname,string majorid,string majorname) {
           config_majorModel cmm = new config_majorModel()            
           { 
           major_kind_id=major_kind_id,
           major_kind_name= majorkindname,
           major_id= majorid,
           major_name= majorname
           };
            int result = await icmb.Add(cmm);
            return result;
        
        }

    }
}
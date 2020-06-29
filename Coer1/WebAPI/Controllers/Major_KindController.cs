using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBLL;
using Model;
using Newtonsoft.Json;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Major_KindController : ControllerBase
    {
        private readonly Iconfig_major_kindBLL icmkb;
        public Major_KindController(Iconfig_major_kindBLL icmkb) {
            this.icmkb = icmkb;
        }


        [HttpGet]
        public async Task<IActionResult> config_major_kindLoad() {
            List<config_major_kindModel> list =await icmkb.Load();
            return Content(JsonConvert.SerializeObject(list));       
        }

        [HttpPost]
        public async Task<int> config_major_kindAdd([FromQuery]string id,string name) {
            config_major_kindModel cmkm = new config_major_kindModel() 
            {
            major_kind_id=id,
            major_kind_name=name
            };

            return await icmkb.Add(cmkm); ;
        }
        
        [HttpDelete]
        public async Task<int> config_major_kindDel([FromQuery]int id) {

            return await icmkb.Delete(id);
        }
    }
}
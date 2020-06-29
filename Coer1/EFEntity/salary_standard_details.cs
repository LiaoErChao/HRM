using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
   public class salary_standard_details
    {
        [Key]
        public int sdt_id { get; set; } //主键，自动增长列

        public string standard_id { get; set; }//薪酬标准单编号      

        public string standard_name { get; set; }//薪酬标准单名称

        public int item_id { get; set; }//薪酬项目序号
        public string item_name { get; set; }//薪酬项目名称

        public double salary { get; set; }//薪酬金额  

    }
}

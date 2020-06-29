using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class config_majorModel
    {
        public int mak_id { get; set; }//主键

        public string major_kind_id { get; set; }//职位分类编号

        public string major_kind_name { get; set; }//职位分类名称

        public string major_id { get; set; }//职位编号

        public string major_name { get; set; }//职位名称

        public int test_amount { get; set; }//题套数量
    }
}

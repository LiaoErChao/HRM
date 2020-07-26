using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    /**
     * 试题一级分类设置
     * 
     */
    public class config_question_first_kindModel
    {
        public int qfk_id { get; set; }//主键
        public string first_kind_id { get; set; }//试题一级分类编号
        public string first_kind_name { get; set; }//试题一级分类名称
    }
}

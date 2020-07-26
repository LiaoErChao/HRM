using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /**
     * 
     * 试卷登记表
     */
    public class engage_examModel
    {
        public int exa_id { get; set; }// 主键
        public string exam_number { get; set; }//试卷编号
        public string major_kind_id { get; set; }//职位分类编号
        public string major_kind_name { get; set; }//职位分类名称
        public string major_id { get; set; }//职位编号
        public string major_name { get; set; }//职位名称
        public string register { get; set; }//登记人
        public DateTime regist_time { get; set; }//登记时间
        public int limite_time { get; set; }//答题限时

    }
}

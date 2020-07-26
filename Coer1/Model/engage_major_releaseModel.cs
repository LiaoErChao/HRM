using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /**
    * 职位发表登记表    
    * 
    */

    public class engage_major_releaseModel
    {

        public int mre_id { get; set; }//主键，自动增长列
        public string first_kind_id { get; set; }//一级机构编号
        public string first_kind_name { get; set; }//一级机构名称
        public string second_kind_id { get; set; }//二级机构编号
        public string second_kind_name { get; set; }//二级机构名称 
        public string third_kind_id { get; set; }//三级机构编号 
        public string third_kind_name { get; set; }//三级机构名称
        public string major_kind_id { get; set; }//职位分类编号 
        public string major_kind_name { get; set; }//职位分类名称
        public string major_id { get; set; }//职位编号
        public string major_name { get; set; }//职位名称
        public int human_amount { get; set; }//招聘人数
        public string engage_type { get; set; }//招聘类型 
        public DateTime deadline { get; set; }//截至日期 
        public string register { get; set; }//登记人
        public string changer { get; set; }//变更人 
        public DateTime regist_time { get; set; }//登记时间
        public DateTime change_time { get; set; }//变更时间
        public string major_describe { get; set; }//职位描述
        public string engage_required { get; set; }//招聘要求
    }
}

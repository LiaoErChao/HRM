using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity.Configer
{
    /**
     * 激励登记表
     * 
     */
    public class bonus
    {
        [Key]
        public int bon_id { get; set; }//主键
        public string major_kind_id { get; set; }//职位分类编号
        public string major_kind_name { get; set; }//职位分类名称
        public string major_id { get; set; }//职位编号
        public string major_name { get; set; }//职位名称
        public string human_id { get; set; }//人力资源档案编号
        public string human_name { get; set; }//姓名
        public string bonus_item { get; set; }//激励项目名称
        public double bonus_worth { get; set; }//激励价值
        public string bonus_degree { get; set; }//激励等级
        public string remark { get; set; }//备注
        public string register { get; set; }//登记人
        public string checker { get; set; }//复核人
        public DateTime regist_time { get; set; }//登记时间
        public DateTime check_time { get; set; }//复核时间
        public int check_status { get; set; }//复核状态


    }
}

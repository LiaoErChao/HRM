using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 培训登记表
     * 
     */
    public class training
    {
        [Key]
        public int tra_id { get; set; }//主键
        public string major_kind_id { get; set; }//职位分类编号
        public string major_kind_name { get; set; }//职位分类名称
        public string major_id { get; set; }//职位名称
        public string major_name { get; set; }//职位名称
        public string human_id { get; set; }//人力资源档案编号
        public string human_name { get; set; }//姓名
        public string training_item { get; set; }//培训项目
        public DateTime training_time { get; set; }//培训时间
        public int training_hour { get; set; }//培训课时
        public string training_degree { get; set; }//培训成绩等级
        public string register { get; set; }//登记人
        public string checker { get; set; }//复核人
        public DateTime regist_time { get; set; }//登记时间
        public DateTime check_time { get; set; }//复核时间
        public int checkstatus { get; set; }//培训复核状态
        public string remark { get; set; }//备注
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 公共字段设置，包括薪酬设置，职称设置，国籍，民族，宗教信仰，政治面貌，教育年限，学历,
     * 专业，特长，爱好，培训项目，培训成绩，奖励项目，奖励等级
     * 
     */
    public class config_public_char
    {

        [Key]
        public int pbc_id { get; set; }//主键
        public string attribute_kind { get; set; }//属性的种类  
        public string attribute_name { get; set; }//属性的名称
    }
}

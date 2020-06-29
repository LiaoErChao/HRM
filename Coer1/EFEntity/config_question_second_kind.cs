using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 试题二级分类设置
     * 
     */
    public class config_question_second_kind
    {

        [Key]
        public int qsk_id { get; set; }//主键
        public string first_kind_id { get; set; }//试题一级分类编号
        public string first_kind_name { get; set; }//试题一级分类名称
        public string second_kind_id { get; set; }//试题二级分类编号
        public string second_kind_name { get; set; }//试题二级分类名称
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 试卷详细信息
     * 
     */
    public class engage_exam_details
    {
        [Key]
        public int exd_id { get; set; }//主键，自动增长列 
        public string exam_number { get; set; }//试卷编号
        public string first_kind_id { get; set; }//试题一级分类编号
        public string first_kind_name { get; set; }//试题一级分类名称
        public string second_kind_id { get; set; }//试题二级分类编号
        public string second_kind_name { get; set; }//试题二级分类名称
        public int question_amount { get; set; }//出题数量

    }
}

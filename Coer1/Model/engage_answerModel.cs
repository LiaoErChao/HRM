using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /**
     * 
     * 考试答题登记表 
     * 
     */

    public class engage_answerModel
    {

        public int ans_id { get; set; }//主键
        public string answer_number { get; set; }//答案编号
        public string exam_number { get; set; }//试卷编号
        public int resume_id { get; set; }//简历编号
        public int interview_id { get; set; }//面试编号
        public string human_name { get; set; }//姓名
        public string human_idcard { get; set; }//身份证号
        public string major_kind_id { get; set; }//职位分类编号
        public string major_kind_name { get; set; }//major_kind_name 属于 engage_answer 
        public string major_id { get; set; }//major_id 属于 engage_answer 
        public string major_name { get; set; }//major_name 属于 engage_answer
        public DateTime test_time { get; set; }//测试时间
        public string use_time { get; set; }//use_time 属于 engage_answer
        public double total_point { get; set; }//总分
    }
}

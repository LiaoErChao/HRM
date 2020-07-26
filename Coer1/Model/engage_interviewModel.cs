using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /**
     * 面试表
     * 
     * 
     */
    public class engage_interviewModel
    {
        public int ein_id { get; set; }//主键
        public string human_name { get; set; }//姓名
        public int interview_amount { get; set; }//面试次数
        public string human_major_kind_id { get; set; }//职位分类编号
        public string human_major_kind_name { get; set; }//职位分类名称
        public string human_major_id { get; set; }//职位编号
        public string human_major_name { get; set; }//职位名称
        public string image_degree { get; set; }//形象等级
        public string native_language_degree { get; set; }//口才等级
        public int foreign_language_degree { get; set; }//外语水平等级
        public string response_speed_degree { get; set; }//应变能力
        public string EQ_degree { get; set; }//EQ等级
        public string IQ_degree { get; set; }//EQ等级
        public string multi_quality_degree { get; set; }//综合素质
        public string register { get; set; }//面试人
        public string checker { get; set; }//筛选人
        public DateTime registe_time { get; set; }//面试时间
        public DateTime check_time { get; set; }//筛选时间
        public int resume_id { get; set; }//简历编号
        public string result { get; set; }//面试结果
        public string interview_comment { get; set; }//面试评价
        public string check_comment { get; set; }//筛选评价
        public int interview_status { get; set; }//面试状态
        public int check_status { get; set; }//筛选状态

    }
}

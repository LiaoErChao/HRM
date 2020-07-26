using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class engage_resumeModel
    {
        public int res_id { get; set; }//主键
        public string human_name { get; set; }//姓名
        public string engage_type { get; set; }//招聘类型
        public string human_address { get; set; }//地址
        public string human_postcode { get; set; }//邮编
        public string human_major_kind_id { get; set; }//职位分类编号
        public string human_major_kind_name { get; set; }//职位分类名称
        public string human_major_id { get; set; }//职位编号
        public string human_major_name { get; set; }//职位名称
        public string human_telephone { get; set; }//电话号码
        public string human_homephone { get; set; }//家庭电话
        public string human_mobilephone { get; set; }//手机
        public string human_email { get; set; }//Email
        public string human_hobby { get; set; }//兴趣爱好
        public string human_specility { get; set; }//特长
        public string human_sex { get; set; }//性别
        public string human_religion { get; set; }//宗教信仰
        public string human_party { get; set; }//政治面貌
        public string human_nationality { get; set; }//国籍
        public string human_race { get; set; }//民族
        public DateTime human_birthday { get; set; }//生日
        public int human_age { get; set; }//年龄
        public string human_educated_degree { get; set; }//教育程度
        public int human_educated_years { get; set; }//教育年限
        public string human_educated_major { get; set; }//专业
        public string human_college { get; set; }//毕业院校
        public string human_idcard { get; set; }//身份证号
        public string human_birthplace { get; set; }//出生地
        public double demand_salary_standard { get; set; }//薪酬标准
        public string human_history_records { get; set; }//个人履历
        public string remark { get; set; }//备注
        public string recomandation { get; set; }//推荐意见
        public string human_picture { get; set; }//照片
        public string attachment_name { get; set; }//档案附件
        public int check_status { get; set; }//复核状态
        public string register { get; set; }//登记人
        public DateTime regist_time { get; set; }//登记时间
        public string checker { get; set; }//复核人姓名
        public DateTime check_time { get; set; }//复核时间
        public int interview_status { get; set; }//面试状态
        public float total_points { get; set; }//总分
        public int test_amount { get; set; }//考试次数
        public string test_checker { get; set; }//测试复核人
        public DateTime test_check_time { get; set; }//测试复核时间
        public string pass_register { get; set; }//通过登记人姓名
        public DateTime pass_regist_time { get; set; }//通过登记时间
        public string pass_checker { get; set; }//通过复核人姓名
        public DateTime pass_check_time { get; set; }//通过复核时间
        public int pass_check_status { get; set; }//通过的复核状态
        public string pass_checkComment { get; set; }//录用申请审核意见
        public string pass_passComment { get; set; }//录用申请审批意见
    }
}

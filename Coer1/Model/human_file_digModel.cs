using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /**
     * 记录人力资源档案所做的任何更改
     */
    public class human_file_digModel
    {

        public int hfd_id { get; set; }//主键
        public string human_id { get; set; }//档案编号
        public string first_kind_id { get; set; }//一级机构编号
        public string first_kind_name { get; set; }//一级机构名称
        public string second_kind_id { get; set; }//二级机构编号
        public string second_kind_name { get; set; }//二级机构名称
        public string third_kind_id { get; set; }//三级机构编号
        public string third_kind_name { get; set; }//三级机构名称
        public string human_name { get; set; }//姓名
        public string human_address { get; set; }//地址
        public string human_postcode { get; set; }//邮政编码
        public string human_pro_designation { get; set; }//职称
        public string human_major_kind_id { get; set; }//职位分类编号
        public string human_major_kind_name { get; set; }//职位分类名称
        public string human_major_id { get; set; }//职位编号
        public string hunma_major_name { get; set; }//职位名称
        public string human_telephone { get; set; }//电话
        public string human_mobilephone { get; set; }//手机号码
        public string human_bank { get; set; }//开户银行
        public string human_account { get; set; }//银行帐号
        public string human_qq { get; set; }//QQ号码
        public string human_email { get; set; }//电子邮件
        public string human_hobby { get; set; }//爱好
        public string human_speciality { get; set; }//特长
        public string human_sex { get; set; }//性别
        public string human_religion { get; set; }//宗教信仰
        public string human_party { get; set; }//政治面貌
        public string human_nationality { get; set; }//国籍
        public string human_race { get; set; }//民族
        public DateTime human_birthday { get; set; }//出生日期
        public string human_birthplace { get; set; }//出生地
        public int human_age { get; set; }//年龄
        public string human_educated_degree { get; set; }//学历
        public int human_educated_years { get; set; }//教育年限
        public string human_educated_major { get; set; }//学历专业
        public string human_society_security_id { get; set; }//社会保障号
        public string human_id_card { get; set; }//身份证号
        public string remark { get; set; }//备注
        public string salary_standard_id { get; set; }//薪酬标准编号
        public string salary_standard_name { get; set; }//薪酬标准名称
        public double salary_sum { get; set; }//基本薪酬总额
        public double demand_salaray_sum { get; set; }//应发薪酬总额
        public double paid_salary_sum { get; set; }//实发薪酬总额
        public int major_change_amount { get; set; }//调动次数
        public int bonus_amount { get; set; }//激励累计次数
        public int training_amount { get; set; }//培训累计次数
        public int file_chang_amount { get; set; }//档案变更累计次数
        public string human_histroy_records { get; set; }//简历
        public string human_family_membership { get; set; }//家庭关系
        public string human_picture { get; set; }//相片
        public string attachment_name { get; set; }//附件名称
        public int check_status { get; set; }//复核状态
        public string register { get; set; }//档案登记人
        public string checker { get; set; }//档案复核人
        public string changer { get; set; }//档案变更人
        public DateTime regist_time { get; set; }//档案登记时间
        public DateTime check_time { get; set; }//档案复核时间
        public DateTime change_time { get; set; }//档案变更时间
        public DateTime lastly_change_time { get; set; }//档案最近更改时间
        public DateTime delete_time { get; set; }//档案删除时间
        public DateTime recovery_time { get; set; }//档案恢复时间
        public string human_file_status { get; set; }//档案状态
    }
}

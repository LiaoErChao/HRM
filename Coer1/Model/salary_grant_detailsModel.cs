using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /**
     * 
     *  薪酬发放详细信息
     */
    public class salary_grant_detailsModel
    {
        public int grd_id { get; set; }//主键，自动增长列  
        public string salary_grant_id { get; set; }//薪酬发放编号
        public string human_id { get; set; }//档案编号
        public string human_name { get; set; }//姓名
        public double bouns_sum { get; set; }//奖励金额
        public double sale_sum { get; set; }//销售绩效金额
        public double deduct_sum { get; set; }//应扣金额
        public double salary_standard_sum { get; set; }//标准薪酬总额
        public double salary_paid_sum { get; set; }//实发薪酬总额
    }
}

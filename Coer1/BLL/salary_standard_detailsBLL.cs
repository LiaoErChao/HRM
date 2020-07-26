using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;
using System.Threading.Tasks;

namespace BLL
{
    public class salary_standard_detailsBLL : Isalary_standard_detailsBLL
    {
        private readonly Isalary_standard_detailsDAO issdd;

        public salary_standard_detailsBLL(Isalary_standard_detailsDAO issdd) {
            this.issdd = issdd;

        }

        //添加
        public Task<int> salary_standard_detailsAdd(salary_standard_detailsModel ssdm)
        {
            return issdd.salary_standard_detailsAdd(ssdm);
        }

        //查询
        public List<salary_standard_detailsModel> Select()
        {
            return issdd.Select();
        }
        
        //修改
        public Task<int> Update(salary_standard_detailsModel s)
        {
            return issdd.Update(s);
        }
    }
}

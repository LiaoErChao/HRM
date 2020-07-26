using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class salary_standardDAO : Isalary_standardDAO
    {
        private readonly TescDbContext hr;
        public salary_standardDAO(TescDbContext hr)
        {
            this.hr = hr;
        }
        public List<salary_standardModel> Select()
        {
            List<salary_standard> list = hr.salary_Standards.ToList();
            List<salary_standardModel> list2 = new List<salary_standardModel>();
            //需要把ED->DTO
            foreach (salary_standard item in list)
            {
                salary_standardModel bjm = new salary_standardModel()
                {
                    ssd_id = item.ssd_id,
                    standard_id = item.standard_id,
                    standard_name = item.standard_name,
                    designer = item.designer,
                    register = item.register,
                    checker = item.checker,
                    changer = item.changer,
                    regist_time = item.regist_time,
                    check_time = item.check_time,
                    change_time = item.change_time,
                    check_status = item.check_status,
                    change_status = item.change_status,
                    check_comment = item.check_comment,
                    salary_sum = item.salary_sum,
                    remark = item.remark
                };
                list2.Add(bjm);
            }
            return list2;
        }
    }
}

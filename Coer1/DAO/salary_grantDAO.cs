using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class salary_grantDAO : Isalary_grantDAO
    {
        private readonly TescDbContext tescDbContext;
        public salary_grantDAO(TescDbContext tescDbContext) {
            this.tescDbContext = tescDbContext;
        
        }
        public async Task<List<salary_grantModel>> Select()
        {
            List<salary_grant> list =await Task.Run(() => { return  tescDbContext.sg.ToList(); });
            List<salary_grantModel> listm = new List<salary_grantModel>();

            foreach (salary_grant item in list)
            {
                salary_grantModel sgm = new salary_grantModel()
                {
                    salary_grant_id=item.salary_grant_id,
                    salary_paid_sum=item.salary_paid_sum,
                    salary_standard_id=item.salary_standard_id,
                    salary_standard_sum=item.salary_standard_sum,
                    second_kind_id=item.second_kind_id,
                    second_kind_name=item.second_kind_name,
                    sgr_id=item.sgr_id,
                    checker=item.checker,
                    check_status=item.check_status,
                    check_time=item.check_time,
                    first_kind_id=item.first_kind_id,
                    first_kind_name=item.first_kind_name,
                    human_amount=item.human_amount,
                    third_kind_id=item.third_kind_id,
                    third_kind_name=item.third_kind_name,
                    register=item.register,
                    regist_time=item.regist_time
                };
                listm.Add(sgm);
            }

            return listm;
            
        }
    }
}

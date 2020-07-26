using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class salary_grantBLL : Isalary_grantBLL
    {
        private readonly Isalary_grantDAO isgd;
        public salary_grantBLL(Isalary_grantDAO isgd)
        {
            this.isgd = isgd;
        }
        public Task<List<salary_grantModel>> Select()
        {
            return isgd.Select();
        }
    }
}

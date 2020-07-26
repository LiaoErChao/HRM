using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class salary_standardBLL : Isalary_standardBLL
    {
        private readonly Isalary_standardDAO ss;
        public salary_standardBLL(Isalary_standardDAO ss)
        {
            this.ss = ss;
        }
        public List<salary_standardModel> Select()
        {
            return ss.Select();
        }
    }
}

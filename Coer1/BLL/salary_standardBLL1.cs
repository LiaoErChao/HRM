using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
   public class salary_standardBLL1:Isalary_standardBLL1
    {
        private readonly Isalary_standardDAO1 issd;

        public salary_standardBLL1(Isalary_standardDAO1 issd) {
            this.issd = issd;
        }


        //分页查询
        public DBFenYe<salary_standardModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return issd.Fenye(dqy, tablename, where, keyname, pagesize);
        }

        //添加
        public Task<int> salary_standardAdd(salary_standardModel1 ssm)
        {
            return issd.salary_standardAdd(ssm);
        }


        //查询
        public List<salary_standardModel1> Select()
        {
            return issd.Select();
        }
        //变更修改
        public Task<int> Upd(salary_standardModel1 s)
        {
            return issd.Upd(s);
        }

        //复核修改
        public Task<int> Update(salary_standardModel1 s)
        {
            return issd.Update(s);    
        }
    }
}

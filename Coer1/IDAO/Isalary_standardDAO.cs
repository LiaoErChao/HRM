using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Isalary_standardDAO
    {

        //添加
        Task<int> salary_standardAdd(salary_standardModel1 ssm);

        //分页查询
        DBFenYe<salary_standardModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);

        //查询
       List<salary_standardModel1> Select();

        //复核修改
        Task<int> Update(salary_standardModel1 s);

        //变更修改

        Task<int> Upd(salary_standardModel1 s);
    }
}

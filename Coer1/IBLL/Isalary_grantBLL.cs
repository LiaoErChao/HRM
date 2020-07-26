using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
  public  interface Isalary_grantBLL
    {
        //查询
        Task<List<salary_grantModel>> Select();
    }
}

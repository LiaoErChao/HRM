using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Isalary_grantDAO
    {

        //查询
        Task<List<salary_grantModel>> Select();
    }
}

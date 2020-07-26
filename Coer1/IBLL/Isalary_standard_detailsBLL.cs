using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Isalary_standard_detailsBLL
    {

        //添加
        Task<int> salary_standard_detailsAdd(salary_standard_detailsModel ssdm);

        //查询
        List<salary_standard_detailsModel> Select();

        //修改
        Task<int> Update(salary_standard_detailsModel s);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Iconfig_majorbBLL1
    {
        //查询   
        Task<List<config_majorModel1>> Load();

        //删除
        Task<int> Delete(int id);

        //添加    
        Task<int> Add(config_majorModel1 cmm);
    }
}

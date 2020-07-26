using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Iconfig_majorDAO
    {
        //查询   
        Task<List<config_majorModel>> Load();
        List<config_majorModel> Select();

        //删除
        Task<int> Delete(int id);

        //添加    
        Task<int> Add(config_majorModel cmm);


    }
}

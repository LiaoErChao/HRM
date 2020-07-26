using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;
namespace IBLL
{
   public interface Iconfig_major_kindBLL
    {
        //查询   
        Task<List<config_major_kindModel1>> Load();
        List<config_major_kindModel1> Select();
        //删除
        Task<int> Delete(int id);

        //添加    
        Task<int> Add(config_major_kindModel1 cmm);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Iconfig_file_second_kindBLL
    {
        //查询
        Task<List<config_file_second_kindModel>> Load();

        List<config_file_second_kindModel> Loads();
        //查询一级机构编号
        Task<List<config_file_first_kindModel>> SelectYiJiJG();
        //添加
        Task<int> ADD(config_file_second_kindModel cffskm);

        //修改查询
        Task<config_file_second_kindModel> Up(int id);

        //修改
        Task<int> Update(config_file_second_kindModel cffskm);

        //删除
        Task<int> Delete(int id);

    }
}

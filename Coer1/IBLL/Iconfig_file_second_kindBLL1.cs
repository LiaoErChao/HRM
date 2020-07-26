using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Iconfig_file_second_kindBLL1
    {
        //查询
        Task<List<config_file_second_kindModel1>> Load();

        //查询一级机构编号
        Task<List<config_file_first_kindModel1>> SelectYiJiJG();
        //添加
        Task<int> ADD(config_file_second_kindModel1 cffskm);

        //修改查询
        Task<config_file_second_kindModel1> Up(int id);

        //修改
        Task<int> Update(config_file_second_kindModel1 cffskm);

        //删除
        Task<int> Delete(int id);

    }
}

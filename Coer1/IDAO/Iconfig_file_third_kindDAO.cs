using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
  public interface Iconfig_file_third_kindDAO
    {
        //查询
        Task<List<config_file_third_kindModel1>> Select();

        List<config_file_third_kindModel1> Selectt();

        //修改
        Task<int> Update(config_file_third_kindModel1 cftkm);

        //修改查询
        Task<config_file_third_kindModel1> UpSelect(int id);

        //删除
        Task<int> Delete(int id);

        //一级机构查询
        Task<List<config_file_first_kindModel1>> SelectYiJiJG();

        //二级机构查询
        Task<List<config_file_second_kindModel1>> SelectErJiJG();

        //添加
        Task<int> ADD(config_file_third_kindModel1 cftkm);

    }
}

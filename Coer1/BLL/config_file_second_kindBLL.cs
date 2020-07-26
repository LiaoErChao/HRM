using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class config_file_second_kindBLL : Iconfig_file_second_kindBLL
    {
        private readonly Iconfig_file_second_kindDAO iconfig;

        public config_file_second_kindBLL(Iconfig_file_second_kindDAO iconfig) {
            this.iconfig = iconfig;       
        }



        //添加
        public Task<int> ADD(config_file_second_kindModel cffskm)
        {
            return iconfig.ADD(cffskm);
        }

        //删除
        public Task<int> Delete(int id)
        {
            return iconfig.Delete(id);
        }

        //查询
        public Task<List<config_file_second_kindModel>> Load()
        {
            return iconfig.Load();
        }

        public List<config_file_second_kindModel> Loads()
        {
            return iconfig.Loads();
        }


        //一级机构查询
        public Task<List<config_file_first_kindModel>> SelectYiJiJG()
        {
            return iconfig.SelectYiJiJG();
        }


        //修改查询
        public Task<config_file_second_kindModel> Up(int id)
        {
            return iconfig.Up(id);
        }

        //修改
        public Task<int> Update(config_file_second_kindModel cffskm)
        {
            return iconfig.Update(cffskm);
        }
    }
}

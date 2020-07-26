using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class config_majorBLL1 : Iconfig_majorbBLL1
    {

        private readonly Iconfig_majorDAO1 icmd;
        public config_majorBLL1(Iconfig_majorDAO1 icmd) {
            this.icmd = icmd;
        }


        //添加
        public Task<int> Add(config_majorModel1 cmm)
        {
            return icmd.Add(cmm);
        }

        //删除
        public Task<int> Delete(int id)
        {
            return icmd.Delete(id);
        }


        //查询
        public Task<List<config_majorModel1>> Load()
        {
            return icmd.Load();
        }
    }
}

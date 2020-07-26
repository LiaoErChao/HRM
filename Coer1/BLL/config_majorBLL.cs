using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class config_majorBLL : Iconfig_majorbBLL
    {

        private readonly Iconfig_majorDAO icmd;
        public config_majorBLL(Iconfig_majorDAO icmd) {
            this.icmd = icmd;
        }


        //添加
        public Task<int> Add(config_majorModel cmm)
        {
            return icmd.Add(cmm);
        }

        //删除
        public Task<int> Delete(int id)
        {
            return icmd.Delete(id);
        }


        //查询
        public Task<List<config_majorModel>> Load()
        {
            return icmd.Load();
        }

        public List<config_majorModel> Select()
        {
            return icmd.Select();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class config_major_kindBLL1 : Iconfig_major_kindBLL
    {
        private readonly Iconfig_major_kindDAO icmkd;
        public config_major_kindBLL1(Iconfig_major_kindDAO icmkd) {
            this.icmkd = icmkd;
        }

        public Task<int> Add(config_major_kindModel1 cmm)
        {
            return icmkd.Add(cmm);
        }

        public Task<int> Delete(int id)
        {
            return icmkd.Delete(id);
        }

        public Task<List<config_major_kindModel1>> Load()
        {
            return icmkd.Load();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class config_public_charBLL : Iconfig_public_charBLL
    {


        private readonly Iconfig_public_charDAO icpcd;
        public config_public_charBLL(Iconfig_public_charDAO icpcd) {
            this.icpcd = icpcd;
        
        }

        public Task<int> Add(config_public_charModel cpcm)
        {
            return icpcd.Add(cpcm);
        }

        public Task<int> Delete(int id)
        {
            return icpcd.Delete(id);
        }

        public Task<List<config_public_charModel>> SelectAll()
        {
            return icpcd.SelectAll();
        }

        public Task<config_public_charModel> WhereSelect(int id)
        {
            return icpcd.WhereSelect(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using IBLL;
using Model;

namespace BLL
{
    public class major_changeBLL : Imajor_changeBLL
    {
        private readonly Imajor_changeDAO mc;
        public major_changeBLL(Imajor_changeDAO mc)
        {
            this.mc = mc;
        }
        public Task<int> Ad(major_changeModel m)
        {
            return mc.Ad(m);
        }

        public List<major_changeModel> FenYe(FenYeModel fen)
        {
            return mc.FenYe(fen);
        }

        public Dictionary<int, List<major_changeModel>> FenYeMc(int currpage, int pagesize)
        {
            return mc.FenYeMc(currpage, pagesize);
        }

        public List<major_changeModel> Sel()
        {
            return mc.Sel();
        }

        public major_changeModel SelById(int id)
        {
            return mc.SelById(id);
        }

        public Task<int> Up(int mch_id, major_changeModel m)
        {
            return mc.Up(mch_id, m);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;

namespace BLL
{
    public class human_fileBLL : Ihuman_fileBLL
    {
        private readonly Ihuman_fileDAO hm;
        public human_fileBLL(Ihuman_fileDAO hm)
        {
            this.hm = hm;

        }
        public List<human_fileModel> FenYe(FenYeModel fen)
        {
            return hm.FenYe(fen);
        }

        public Dictionary<int, List<human_fileModel>> Fenyehm(int currepage, int pagesize, string firstname, string secondname, string thirdname, DateTime ktime, DateTime endtime)
        {
            throw new NotImplementedException();
        }

        public int HREdit(human_fileModel h)
        {
            throw new NotImplementedException();
        }

        public human_fileModel SelByID02(int id)
        {
            return hm.SelByID02(id);
        }

        public List<human_fileModel> select()
        {
            throw new NotImplementedException();
        }
    }
}

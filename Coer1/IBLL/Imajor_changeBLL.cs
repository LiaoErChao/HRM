using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface Imajor_changeBLL
    {
        Dictionary<int, List<major_changeModel>> FenYeMc(int currpage, int pagesize);
        Task<int> Ad(major_changeModel m);
        major_changeModel SelById(int id);
        Task<int> Up(int mch_id,major_changeModel m);
        List<major_changeModel> Sel();
        List<major_changeModel> FenYe(FenYeModel fen);
    }
}

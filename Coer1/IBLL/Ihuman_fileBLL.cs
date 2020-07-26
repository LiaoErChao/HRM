using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace IBLL
{
    public interface Ihuman_fileBLL
    {
        List<human_fileModel> select();
        Dictionary<int, List<human_fileModel>> Fenyehm(int currepage, int pagesize, string firstname, string secondname, string thirdname, DateTime ktime, DateTime endtime);
        human_fileModel SelByID02(int id);
        List<human_fileModel> FenYe(FenYeModel fen);
        int HREdit(human_fileModel h);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace IDAO
{
    public interface Ihuman_fileDAO
    {
        List<human_fileModel> FenYe(FenYeModel fen);
        int human_fileAdd(human_fileModel h);
        int human_fileDelete(human_fileModel h);
        int human_fileUpdate(human_fileModel h);
        human_fileModel human_fileUpdateSelect(int id);
        Dictionary<int, List<human_fileModel>> human_fileFenye(int currepage, int pagesize);
        Dictionary<int, List<human_fileModel>> Fenyercx(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5);
        List<human_fileModel> FindFisrt(string firstid);//查询一级机构
        List<human_fileModel> FindSecond(string seconed);//查询二级机构
        List<human_fileModel> Findt(string thrid);//查询三级机构
        List<human_fileModel> FindIdName(int id, string name);//查询各级机构的人
        List<human_fileModel> Findhfd(int id);//根据主键查询
        List<human_fileModel> FindHUmanid(string id);//根据humanid查询
        Dictionary<int, List<human_fileModel>> Fenyercx2(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5);
        Dictionary<int, List<human_fileModel>> Fenyercx3(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5);
        //三部分
        Dictionary<int, List<human_fileModel>> Fenyehm(int currepage, int pagesize, string firstname, string secondname, string thirdname, DateTime ktime, DateTime endtime);
        human_fileModel SelByID02(int id);

        List<human_fileModel> select();
        Dictionary<int, List<human_fileModel>> FenyeHMOne(int currepage, int pagesize, DateTime ktime, DateTime endtime);
        int HREdit(human_fileModel h);
    }
}

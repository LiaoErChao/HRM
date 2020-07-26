using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Ihuman_fileBLL1
    {
        //查询
        Task<List<human_fileModel1>> Select();

        //修改
        Task<int> Update(human_fileModel1 hfm);
        //登记
        Task<int> Denji(human_fileModel1 hfm);
        //分页查询
        DBFenYe<human_fileModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);

    }
}

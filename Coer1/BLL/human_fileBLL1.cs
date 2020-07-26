using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
   public class human_fileBLL1:Ihuman_fileBLL1
    {
        private readonly Ihuman_fileDAO1 ihfd;
        
        public human_fileBLL1(Ihuman_fileDAO1 ihfd)
        {
            this.ihfd = ihfd;
        }

        //登记
        public Task<int> Denji(human_fileModel1 hfm)
        {
            return ihfd.Denji(hfm);
        }

        //分页查询
        public DBFenYe<human_fileModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {
            return ihfd.Fenye(dqy,tablename,where,keyname,pagesize);
        }


        //查询
        public Task<List<human_fileModel1>> Select()
        {
            return ihfd.Select();
        }

        //复核
        public Task<int> Update(human_fileModel1 hfm)
        {
            return ihfd.Update(hfm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using System.Threading.Tasks;
using EFEntity;
using System.Linq;

namespace DAO
{
    public class config_majorDAO : Iconfig_majorDAO
    {

        private readonly TescDbContext tescDbContext;
        public config_majorDAO(TescDbContext tescDbContext)
        {
            this.tescDbContext = tescDbContext;
        }


        //添加
        public async Task<int> Add(config_majorModel cmm)
        {
            config_major cm = new config_major()
            {
                major_id=cmm.major_id,
                major_kind_id=cmm.major_kind_id,
                major_kind_name=cmm.major_kind_name,
                major_name=cmm.major_name,
                mak_id=cmm.mak_id,
                test_amount=cmm.test_amount
            };
            tescDbContext.cfm.Add(cm);
            return await tescDbContext.SaveChangesAsync();
        }

        //删除
        public async Task<int> Delete(int id)
        {
            config_major cm = await tescDbContext.cfm.FindAsync(id);
            tescDbContext.cfm.Remove(cm);
            return await tescDbContext.SaveChangesAsync();
        }

        //查询
        public async Task<List<config_majorModel>> Load()
        {
            List<config_major> list = await Task.Run(() => { return tescDbContext.cfm.ToList(); });
            List<config_majorModel> list2 = new List<config_majorModel>();

            foreach (config_major item in list)
            {

                config_majorModel cffkm = new config_majorModel()
                {
                    major_id = item.major_id,
                    major_kind_id=item.major_kind_id,
                    major_kind_name=item.major_kind_name,
                    major_name=item.major_name,
                    mak_id=item.mak_id,
                    test_amount=item.test_amount
                };

                list2.Add(cffkm);
            }

            return list2;
        }
    }
}

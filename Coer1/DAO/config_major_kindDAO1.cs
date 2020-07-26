using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class config_major_kindDAO1 : Iconfig_major_kindDAO1
    {

        private readonly TescDbContext1 tescDbContext;
        public config_major_kindDAO1(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
        }

        //添加
        public async Task<int> Add(config_major_kindModel1 cmm)
        {
            config_major_kind cm = new config_major_kind()
            {
               mfk_id=cmm.mfk_id,
                major_kind_id = cmm.major_kind_id,
                major_kind_name = cmm.major_kind_name,
               
            };
            tescDbContext.cfmk.Add(cm);
            return await tescDbContext.SaveChangesAsync();
        }

        //删除
        public async Task<int> Delete(int id)
        {
            config_major_kind cm = await tescDbContext.cfmk.FindAsync(id);
            tescDbContext.cfmk.Remove(cm);
            return await tescDbContext.SaveChangesAsync();
        }

        //查询
        public async Task<List<config_major_kindModel1>> Load()
        {
            List<config_major_kind> list = await Task.Run(() => { return tescDbContext.cfmk.ToList(); });
            List<config_major_kindModel1> list2 = new List<config_major_kindModel1>();

            foreach (config_major_kind item in list)
            {


                config_major_kindModel1 cffkm = new config_major_kindModel1()
                {
                   mfk_id=item.mfk_id,
                    major_kind_id = item.major_kind_id,
                    major_kind_name = item.major_kind_name,
                   
                   
                };

                list2.Add(cffkm);
            }

            return list2;
        }
    }
}

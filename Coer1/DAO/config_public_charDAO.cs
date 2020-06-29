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
    public class config_public_charDAO : Iconfig_public_charDAO
    {

        private readonly TescDbContext tescDbContext;
        public config_public_charDAO(TescDbContext tescDbContext)
        {
            this.tescDbContext = tescDbContext;
        }

        //添加
        public async Task<int> Add(config_public_charModel cpcm)
        {
            config_public_char cpc = new config_public_char()
            {
                pbc_id = cpcm.pbc_id,
                attribute_kind = cpcm.attribute_kind,
                attribute_name = cpcm.attribute_name
            };
            tescDbContext.publics.Add(cpc);
            return await tescDbContext.SaveChangesAsync();
        }

        //删除
        public async Task<int> Delete(int id)
        {
            config_public_char cpc = await tescDbContext.publics.FindAsync(id);
            tescDbContext.publics.Remove(cpc);
            return await tescDbContext.SaveChangesAsync();
        }

        //查询
        public async Task<List<config_public_charModel>> SelectAll()
        {
            List<config_public_char> list = await Task.Run(() => { return tescDbContext.publics.ToList();});
            List<config_public_charModel> list2 = new List<config_public_charModel>();

            foreach (config_public_char item in list)
            {

                config_public_charModel cffkm = new config_public_charModel()
                {
                    pbc_id = item.pbc_id,
                    attribute_kind = item.attribute_kind,
                    attribute_name = item.attribute_name
                };

                list2.Add(cffkm);
            }

            return list2;
        }

        //条件查询
        public async Task<config_public_charModel> WhereSelect(int id)
        {
            config_public_char item = await tescDbContext.publics.FindAsync(id);
            config_public_charModel cffkm = new config_public_charModel()
            {
                pbc_id = item.pbc_id,
                attribute_kind = item.attribute_kind,
                attribute_name = item.attribute_name
            };
            return cffkm;
        }
    }
}

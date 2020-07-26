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
   public class config_file_first_kindDAO1:Iconfig_file_first_kindDAO1
    {
        private readonly TescDbContext1 tescDbContext;


       
        public config_file_first_kindDAO1(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
        
        }

        //添加
        public  Task<int> Add(config_file_first_kindModel1 cffk)
        {
            config_file_first_kind ffk = new config_file_first_kind() {
                first_kind_id=cffk.first_kind_id,
                first_kind_name=cffk.first_kind_name,
                first_kind_salary_id=cffk.first_kind_salary_id,
                first_kind_sale_id=cffk.first_kind_sale_id           
            };
            tescDbContext.configs.Add(ffk);
            return tescDbContext.SaveChangesAsync();
        }


        //删除
        public Task<int> Delete(int id)
        {
            config_file_first_kind cffk = new config_file_first_kind()
            {
                ffk_id = id

            };
            tescDbContext.configs.Attach(cffk);
            tescDbContext.configs.Remove(cffk);
            return  tescDbContext.SaveChangesAsync();
        }

        //查询所有
        public Task<List<config_file_first_kindModel1>> SelectAll()
        {
            var list = tescDbContext.configs.ToList();
            List<config_file_first_kindModel1> list2 = new List<config_file_first_kindModel1>();
            var zhi = Task.Run(() =>
            {

                foreach (var item in list)
                {
                    config_file_first_kindModel1 cffkm = new config_file_first_kindModel1()
                    {
                        ffk_id = item.ffk_id,
                        first_kind_id = item.first_kind_id,
                        first_kind_name = item.first_kind_name,
                        first_kind_salary_id = item.first_kind_salary_id,
                        first_kind_sale_id = item.first_kind_sale_id
                    };
                    list2.Add(cffkm);
                }
                return list2;
            });
            return zhi;
        }

        public List<config_file_first_kindModel> Selects()
        {
            var list = tescDbContext.configs.ToList();
            List<config_file_first_kindModel> list2 = new List<config_file_first_kindModel>();
            foreach (var item in list)
            {
                config_file_first_kindModel cffkm = new config_file_first_kindModel()
                {
                    ffk_id = item.ffk_id,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    first_kind_salary_id = item.first_kind_salary_id,
                    first_kind_sale_id = item.first_kind_sale_id
                };
                list2.Add(cffkm);
            }
            return list2;
        }

        //修改
        public async Task<int> Update(config_file_first_kindModel1 cffkm)
        {
            config_file_first_kind cffk = new config_file_first_kind()
            {
                ffk_id = cffkm.ffk_id,
                first_kind_id = cffkm.first_kind_id,
                first_kind_name = cffkm.first_kind_name,
                first_kind_salary_id = cffkm.first_kind_salary_id,
                first_kind_sale_id = cffkm.first_kind_sale_id
            };

            //tescDbContext.Attach(cffk);            
            //tescDbContext.Entry(cffk).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //return await tescDbContext.SaveChangesAsync();

            tescDbContext.Attach(cffk);
            tescDbContext.Entry(cffk).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await tescDbContext.SaveChangesAsync();
        }


        //修改查询
        public async Task<config_file_first_kindModel1> UpSelect(int id)
        {
            config_file_first_kind cffk =await tescDbContext.configs.FindAsync(id);
            config_file_first_kindModel1 cffkm = new config_file_first_kindModel1()
            {
                ffk_id=cffk.ffk_id,
                first_kind_id=cffk.first_kind_id,
                first_kind_name=cffk.first_kind_name,
                first_kind_salary_id=cffk.first_kind_salary_id,
                first_kind_sale_id=cffk.first_kind_sale_id
            };

            return cffkm;
        }


    }
}

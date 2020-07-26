using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Model;

namespace DAO
{
    public class config_file_second_kindDAO1 : Iconfig_file_second_kindDAO1
    {
        private readonly TescDbContext1 tescDbContext;

        public config_file_second_kindDAO1(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
        }

        //添加
        public async Task<int> ADD(config_file_second_kindModel1 cffskm)
        {
            config_file_second_kind cffsk = new config_file_second_kind()
            {
                first_kind_id=cffskm.first_kind_id,
                first_kind_name=cffskm.first_kind_name,
                fsk_id=cffskm.fsk_id,
                second_kind_id=cffskm.second_kind_id,
                second_kind_name=cffskm.second_kind_name,
                second_salary_id=cffskm.second_salary_id,
                second_sale_id=cffskm.second_sale_id
            };
            tescDbContext.second.Add(cffsk);

            return await tescDbContext.SaveChangesAsync();
        }
        
        //删除
        public  Task<int> Delete(int id)
        {
            config_file_second_kind cfsk = new config_file_second_kind()
            {
                fsk_id = id
            };
            tescDbContext.second.Attach(cfsk);
            tescDbContext.second.Remove(cfsk);
            return tescDbContext.SaveChangesAsync();
        }

        //查询
        public Task<List<config_file_second_kindModel1>> Load()
        {
            var list = tescDbContext.second.ToList();
            List<config_file_second_kindModel1> list2 = new List<config_file_second_kindModel1>();
            var zhi = Task.Run(() =>
            {

                foreach (var item in list)
                {
                    config_file_second_kindModel1 cffkm = new config_file_second_kindModel1()
                    {
                      first_kind_id=item.first_kind_id,
                      first_kind_name=item.first_kind_name,
                      fsk_id=item.fsk_id,
                      second_kind_id=item.second_kind_id,
                      second_kind_name=item.second_kind_name,
                      second_salary_id=item.second_salary_id,
                      second_sale_id=item.second_sale_id
                    };
                    list2.Add(cffkm);
                }
                return list2;
            });
            return zhi;
        }

        //查询一级机构编号
        public Task<List<config_file_first_kindModel1>> SelectYiJiJG()
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


        //修改查询
        public async Task<config_file_second_kindModel1> Up(int id)
        {
            config_file_second_kind cffsk = await tescDbContext.second.FindAsync(id);
            config_file_second_kindModel1 cffskm = new config_file_second_kindModel1()
            {
                fsk_id=cffsk.fsk_id,
                first_kind_id=cffsk.first_kind_id,
                first_kind_name=cffsk.first_kind_name,
                second_kind_id=cffsk.second_kind_id,
                second_kind_name=cffsk.second_kind_name,
                second_salary_id=cffsk.second_salary_id,
                second_sale_id=cffsk.second_sale_id
            };

            return cffskm;
        }

        //修改
        public async Task<int> Update(config_file_second_kindModel1 cffskm)
        {
            config_file_second_kind cfsk = new config_file_second_kind()
            {
                fsk_id=cffskm.fsk_id,
                first_kind_id=cffskm.first_kind_id,
                first_kind_name=cffskm.first_kind_name,
                second_kind_id=cffskm.second_kind_id,
                second_kind_name=cffskm.second_kind_name,
                second_salary_id=cffskm.second_salary_id,
                second_sale_id=cffskm.second_sale_id
            };

            tescDbContext.second.Attach(cfsk);
            tescDbContext.Entry(cfsk).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await tescDbContext.SaveChangesAsync();
        }
    }
}

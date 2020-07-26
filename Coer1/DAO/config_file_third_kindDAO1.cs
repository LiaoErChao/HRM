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
    public class config_file_third_kindDAO1 : Iconfig_file_third_kindDAO1
    {

        private readonly TescDbContext1 tescDbContext;

        public config_file_third_kindDAO1(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
       
        }

        //添加
        public async Task<int> ADD(config_file_third_kindModel1 cftkm)
        {
            config_file_third_kind cffsk = new config_file_third_kind()
            {
                first_kind_id = cftkm.first_kind_id,
                first_kind_name = cftkm.first_kind_name,
                ftk_id = cftkm.ftk_id,
                second_kind_id = cftkm.second_kind_id,
                second_kind_name = cftkm.second_kind_name,
                third_kind_id = cftkm.third_kind_id,
                third_kind_is_retail = cftkm.third_kind_is_retail,
                third_kind_name = cftkm.third_kind_name,
                third_kind_sale_id = cftkm.third_kind_sale_id
            };
            tescDbContext.third.Add(cffsk);
            return await tescDbContext.SaveChangesAsync();
        }

        //删除
        public Task<int> Delete(int id)
        {
            config_file_third_kind cfsk = new config_file_third_kind()
            {
                ftk_id = id
            };
            tescDbContext.third.Attach(cfsk);
            tescDbContext.third.Remove(cfsk);
            return tescDbContext.SaveChangesAsync();
        }

        //查询
        public List<config_file_third_kindModel1> Select()
        {
            var list = tescDbContext.third.ToList();
            List<config_file_third_kindModel1> list2 = new List<config_file_third_kindModel1>();
           
                foreach (var item in list)
                {
                    config_file_third_kindModel1 cftkm = new config_file_third_kindModel1()
                    {
                        first_kind_id=item.first_kind_id,
                        first_kind_name=item.first_kind_name,
                        ftk_id=item.ftk_id,
                        second_kind_id=item.second_kind_id,
                        second_kind_name=item.second_kind_name,
                        third_kind_id=item.third_kind_id,
                        third_kind_is_retail=item.third_kind_is_retail,
                        third_kind_name=item.third_kind_name,
                        third_kind_sale_id=item.third_kind_sale_id
                    };
                    list2.Add(cftkm);
                }          
            return list2;
        }

        //二级机构查询
        public List<config_file_second_kindModel1> SelectErJiJG()
        {
            var list = tescDbContext.second.ToList();
            List<config_file_second_kindModel1> list2 = new List<config_file_second_kindModel1>();
          

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
        }

        public List<config_file_third_kindModel1> Selectt()
        {
            var list = tescDbContext.third.ToList();
            List<config_file_third_kindModel1> list2 = new List<config_file_third_kindModel1>();
            foreach (var item in list)
            {
                config_file_third_kindModel1 cftkm = new config_file_third_kindModel1()
                {
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    ftk_id = item.ftk_id,
                    second_kind_id = item.second_kind_id,
                    second_kind_name = item.second_kind_name,
                    third_kind_id = item.third_kind_id,
                    third_kind_is_retail = item.third_kind_is_retail,
                    third_kind_name = item.third_kind_name,
                    third_kind_sale_id = item.third_kind_sale_id
                };
                list2.Add(cftkm);
            }
            return list2;
        }

        //一级机构查询
        public List<config_file_first_kindModel1> SelectYiJiJG()
        {
            var list = tescDbContext.configs.ToList();
            List<config_file_first_kindModel1> list2 = new List<config_file_first_kindModel1>();
           

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
        }

        //修改
        public async Task<int> Update(config_file_third_kindModel1 cftkm)
        {
            config_file_third_kind cftk = new config_file_third_kind()
            {
                first_kind_id = cftkm.first_kind_id,
                first_kind_name = cftkm.first_kind_name,
                ftk_id = cftkm.ftk_id,
                second_kind_id = cftkm.second_kind_id,
                second_kind_name = cftkm.second_kind_name,
                third_kind_id = cftkm.third_kind_id,
                third_kind_is_retail = cftkm.third_kind_is_retail,
                third_kind_name = cftkm.third_kind_name,
                third_kind_sale_id = cftkm.third_kind_sale_id
            };

            tescDbContext.third.Attach(cftk);
            tescDbContext.Entry(cftk).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await tescDbContext.SaveChangesAsync();
        }

        //修改查询
        public async Task<config_file_third_kindModel1> UpSelect(int id)
        {
            config_file_third_kind cffsk = await tescDbContext.third.FindAsync(id);
            config_file_third_kindModel1 cffskm = new config_file_third_kindModel1()
            {
                first_kind_id = cffsk.first_kind_id,
                first_kind_name = cffsk.first_kind_name,
                ftk_id = cffsk.ftk_id,
                second_kind_id = cffsk.second_kind_id,
                second_kind_name = cffsk.second_kind_name,
                third_kind_id = cffsk.third_kind_id,
                third_kind_is_retail = cffsk.third_kind_is_retail,
                third_kind_name = cffsk.third_kind_name,
                third_kind_sale_id = cffsk.third_kind_sale_id
            };

            return cffskm;
        }
    }
}

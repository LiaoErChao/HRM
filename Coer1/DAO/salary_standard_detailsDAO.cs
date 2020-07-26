using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EFEntity;
using IDAO;
using Microsoft.EntityFrameworkCore;
using Model;
namespace DAO
{
    public class salary_standard_detailsDAO : Isalary_standard_detailsDAO
    {
        private readonly TescDbContext1 tescDbContext;
        public salary_standard_detailsDAO(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
        }

        //添加
        public async Task<int> salary_standard_detailsAdd(salary_standard_detailsModel ssdm)
        {
            salary_standard_details ssd1 = new salary_standard_details()
            {
                sdt_id=ssdm.sdt_id,
                salary=ssdm.salary,
                standard_id=ssdm.standard_id,
                standard_name=ssdm.standard_name,
                item_id=ssdm.item_id,
                item_name=ssdm.item_name
            };
            tescDbContext.ssd.Add(ssd1);
            return await tescDbContext.SaveChangesAsync();
        }


        //查询
        public List<salary_standard_detailsModel> Select()
        {
            List<salary_standard_details> list = tescDbContext.ssd.ToList();
            List<salary_standard_detailsModel> list2 = new List<salary_standard_detailsModel>();

            foreach (var item in list)
            {
                salary_standard_detailsModel ssm = new salary_standard_detailsModel()
                {
                    sdt_id = item.sdt_id,
                    standard_id = item.standard_id,
                    standard_name = item.standard_name,
                    item_id = item.item_id,
                    item_name = item.item_name,
                    salary = item.salary
                };
                list2.Add(ssm);
            }

            return list2;
        }


      


        //复核修改
        public async Task<int> Update(salary_standard_detailsModel s)
        {
            salary_standard_details ss = new salary_standard_details()
            {
                sdt_id = s.sdt_id,
                item_name = s.item_name,
                salary = s.salary,
                standard_id = s.standard_id,
                standard_name = s.standard_name
            };

            tescDbContext.ssd.Attach(ss);
            //修改指定的列
            tescDbContext.Entry(ss).Property(p => p.item_name).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.salary).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_id).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_name).IsModified = true;
           
            return await tescDbContext.SaveChangesAsync();
        }
    }
}

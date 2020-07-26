using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DAO
{
    public class salary_standardDAO1 : Isalary_standardDAO1
    {
        private readonly TescDbContext1 tescDbContext;

        public salary_standardDAO1(TescDbContext1 tescDbContext) {
            this.tescDbContext = tescDbContext;
        }

        //添加
        public async Task<int> salary_standardAdd(salary_standardModel1 ssm)
        {
            salary_standard ss1 = new salary_standard()
            {
                salary_sum=ssm.salary_sum,
                ssd_id=ssm.ssd_id,
                standard_id=ssm.standard_id,
                standard_name=ssm.standard_name,
                change_status=ssm.change_status,
                changer=ssm.changer,
                change_time=ssm.change_time,
                checker=ssm.checker,
                check_comment=ssm.check_comment,
                check_status=0,
                check_time=ssm.check_time,
                designer=ssm.designer,
                register=ssm.register,
                regist_time=ssm.regist_time,
                remark=ssm.remark
              

            };

            tescDbContext.ss.Add(ss1);
            return await tescDbContext.SaveChangesAsync();
        }


        //分页查询
        public DBFenYe<salary_standardModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
        {

            SqlParameter[] pt =
           {
                new SqlParameter(){ParameterName="@pageSize",Value=pagesize},
                new SqlParameter(){ParameterName="@keyName",Value=keyname},
                new SqlParameter(){ParameterName="@tabelName",Value=tablename},
                new SqlParameter(){ParameterName="@where",Value=where},
                new SqlParameter(){ParameterName="@currentPage",Value=dqy},
                new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
            };
            var list = tescDbContext.ss.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<salary_standardModel1> page = new DBFenYe<salary_standardModel1>();
            page.li = new List<salary_standardModel1>();
            foreach (var sr in list)
            {
                salary_standardModel1 ss = new salary_standardModel1()
                {
                    ssd_id = sr.ssd_id,
                    standard_id = sr.standard_id,
                    standard_name = sr.standard_name,
                    designer = sr.designer,
                    regist_time = sr.regist_time,
                    salary_sum = sr.salary_sum
                };
                page.li.Add(ss);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }

        //查询
        public  List<salary_standardModel1> Select()
        {
            List<salary_standard> ss = tescDbContext.ss.ToList();
            List<salary_standardModel1> ssm = new List<salary_standardModel1>() { };

            foreach (var item in ss)
            {
                salary_standardModel1 sm = new salary_standardModel1()
                {
                    ssd_id = item.ssd_id,
                    standard_name = item.standard_name,
                    standard_id = item.standard_id,
                    designer = item.designer,
                    salary_sum = item.salary_sum,
                    checker = item.checker,
                    change_time = item.change_time,
                    check_comment = item.check_comment

                };
                ssm.Add(sm);
            }
            return ssm;
        }

        //修改
        public async Task<int> Update(salary_standardModel1 s)
        {
          
            salary_standard ss = new salary_standard()
            {
                ssd_id = s.ssd_id,
                checker = s.checker,
                salary_sum = s.salary_sum,
                change_time = s.check_time,
                check_comment = s.check_comment,
                check_status = 1,
                designer = s.designer,
                standard_id = s.standard_id,
                standard_name = s.standard_name
            };

            tescDbContext.ss.Attach(ss);
            //修改指定的列
            tescDbContext.Entry(ss).Property(p => p.checker).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.salary_sum).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.check_time).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.check_comment).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.check_status).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.designer).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_id).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_name).IsModified = true;
            
            return await tescDbContext.SaveChangesAsync();


        }

        //变更修改
        public async Task<int> Upd(salary_standardModel1 s)
        {
            salary_standard ss = new salary_standard()
            {
                ssd_id = s.ssd_id,
                changer = s.changer,
                salary_sum = s.salary_sum,
                change_time = s.check_time,
                remark = s.remark,
                check_status = 1,
                designer = s.designer,
                standard_id = s.standard_id,
                standard_name = s.standard_name
            };

            tescDbContext.ss.Attach(ss);
            //修改指定的列
            tescDbContext.Entry(ss).Property(p => p.changer).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.salary_sum).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.change_time).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.remark).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.check_status).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.designer).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_id).IsModified = true;
            tescDbContext.Entry(ss).Property(p => p.standard_name).IsModified = true;

            return await tescDbContext.SaveChangesAsync();
        }
    }
}

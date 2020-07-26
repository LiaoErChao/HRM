using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Threading.Tasks;
using EFEntity.Configer;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace DAO
{
    public class major_changeDAO : Imajor_changeDAO
    {
        private readonly TescDbContext1 hr;
        public major_changeDAO(TescDbContext1 hr)
        {
            this.hr = hr;
        }
        public async Task<int> Ad(major_changeModel m)
        {
            major_change mm=new major_change()
            {
                mch_id = m.mch_id,
                first_kind_id = m.first_kind_id,
                first_kind_name = m.first_kind_name,
                second_kind_id = m.second_kind_id,
                second_kind_name = m.second_kind_name,
                third_kind_id = m.third_kind_id,
                third_kind_name = m.third_kind_name,
                major_id = m.major_id,
                major_name = m.major_name,
                major_kind_id = m.major_kind_id,
                major_kind_name = m.major_kind_name,
                new_first_kind_id = m.new_first_kind_id,
                new_first_kind_name = m.new_first_kind_name,
                new_second_kind_id = m.new_second_kind_id,
                new_second_kind_name = m.new_second_kind_name,
                new_third_kind_id = m.new_third_kind_id,
                new_third_kind_name = m.new_third_kind_name,
                new_major_id = m.new_major_id,
                new_major_name = m.new_major_name,
                new_major_kind_id = m.new_major_kind_id,
                new_major_kind_name = m.new_major_kind_name,
                human_id = m.human_id,
                human_name = m.human_name,
                salary_standard_id = m.salary_standard_id,
                salary_standard_name = m.salary_standard_name,
                salary_sum = m.salary_sum,
                new_salary_standard_id = m.new_salary_standard_id,
                new_salary_standard_name = m.new_salary_standard_name,
                new_salary_sum = m.new_salary_sum,
                change_reason = m.change_reason,
                check_reason = m.check_reason,
                check_status = m.check_status,
                register = m.register,
                checker = m.checker,
                regist_time = m.regist_time,
                check_time = m.regist_time
            };
            //hr.Major_change.Attach(mm);
            //hr.Entry(mm).State = System.Data.Entity.EntityState.Modified;
            //return hr.SaveChanges();
            hr.major_Changes.Add(mm);
            return await hr.SaveChangesAsync();
        }

        public List<major_changeModel> FenYe(FenYeModel fen)
        {
            List<major_changeModel> list = new List<major_changeModel>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = hr.major_Changes.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                major_changeModel h = new major_changeModel()
                {

                    mch_id = ad.mch_id,
                    first_kind_id = ad.first_kind_id,
                    first_kind_name = ad.first_kind_name,
                    second_kind_id = ad.second_kind_id,
                    second_kind_name = ad.second_kind_name,
                    third_kind_id = ad.third_kind_id,
                    third_kind_name = ad.third_kind_name,
                    major_id = ad.major_id,
                    major_name = ad.major_name,
                    major_kind_id = ad.major_kind_id,
                    major_kind_name = ad.major_kind_name,
                    new_first_kind_id = ad.new_first_kind_id,
                    new_first_kind_name = ad.new_first_kind_name,
                    new_second_kind_id = ad.new_second_kind_id,
                    new_second_kind_name = ad.new_second_kind_name,
                    new_third_kind_id = ad.new_third_kind_id,
                    new_third_kind_name = ad.new_third_kind_name,
                    new_major_id = ad.new_major_id,
                    new_major_name = ad.new_major_name,
                    new_major_kind_id = ad.new_major_kind_id,
                    new_major_kind_name = ad.new_major_kind_name,
                    human_id = ad.human_id,
                    human_name = ad.human_name,
                    salary_standard_id = ad.salary_standard_id,
                    salary_standard_name = ad.salary_standard_name,
                    salary_sum = ad.new_salary_sum,
                    new_salary_standard_id = ad.new_salary_standard_id,
                    new_salary_standard_name = ad.new_salary_standard_name,
                    new_salary_sum = ad.new_salary_sum,
                    change_reason = ad.change_reason,
                    check_reason = ad.check_reason,
                    check_status = ad.check_status,
                    register = ad.register,
                    checker = ad.checker,
                    regist_time = ad.regist_time,
                    check_time = ad.check_time
                };
                list.Add(h);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public Dictionary<int, List<major_changeModel>> FenYeMc(int currpage, int pagesize)
        {
            throw new NotImplementedException();
        }
        #region 分页
        //public Dictionary<int, List<major_changeModel>> FenYeMc(int currpage, int pagesize)
        //{
        //    Dictionary<int, List<major_change>> dic = FenYeMajor_change(currpage, pagesize);
        //    Dictionary<int, List<major_changeModel>> dic1 = new Dictionary<int, List<major_changeModel>>();
        //    List<major_changeModel> list = new List<major_changeModel>();
        //    int row = 0;
        //    foreach (KeyValuePair<int, List<major_change>> items in dic)
        //    {
        //        row = items.Key;
        //        foreach (major_change m in items.Value)
        //        {
        //            major_changeModel um = new major_changeModel()
        //            {
        //                mch_id = m.mch_id,
        //                first_kind_id = m.first_kind_id,
        //                first_kind_name = m.first_kind_name,
        //                second_kind_id = m.second_kind_id,
        //                second_kind_name = m.second_kind_name,
        //                third_kind_id = m.third_kind_id,
        //                third_kind_name = m.third_kind_name,
        //                major_id = m.major_id,
        //                major_name = m.major_name,
        //                major_kind_id = m.major_kind_id,
        //                major_kind_name = m.major_kind_name,
        //                new_first_kind_id = m.new_first_kind_id,
        //                new_first_kind_name = m.new_first_kind_name,
        //                new_second_kind_id = m.new_second_kind_id,
        //                new_second_kind_name = m.new_second_kind_name,
        //                new_third_kind_id = m.new_third_kind_id,
        //                new_third_kind_name = m.new_third_kind_name,
        //                new_major_id = m.new_major_id,
        //                new_major_name = m.new_major_name,
        //                new_major_kind_id = m.new_major_kind_id,
        //                new_major_kind_name = m.new_major_kind_name,
        //                human_id = m.human_id,
        //                human_name = m.human_name,
        //                salary_standard_id = m.salary_standard_id,
        //                salary_standard_name = m.salary_standard_name,
        //                salary_sum = m.new_salary_sum,
        //                new_salary_standard_id = m.new_salary_standard_id,
        //                new_salary_standard_name = m.new_salary_standard_name,
        //                new_salary_sum = m.new_salary_sum,
        //                change_reason = m.change_reason,
        //                check_reason = m.check_reason,
        //                check_status = m.check_status,
        //                register = m.register,
        //                checker = m.checker,
        //                regist_time = m.regist_time,
        //                check_time = m.check_time
        //            };
        //            list.Add(um);
        //        }

        //    }
        //    dic1.Add(row, list);
        //    return dic1;
        //}
        //public Dictionary<int, List<major_changeModel>> FenYeMc(int currpage, int pagesize)
        //{
        //    var data = hr.major_Changes.OrderBy(e => e.mch_id).Where(e => e.check_status != 1);
        //    int rows = data.Count();//总行数
        //    var result = data.Skip((currepage - 1) * pagesize)//忽略多少条
        //          .Take(pagesize);//取多少条
        //    List<major_change> list = new List<major_change>();
        //    list = result.ToList();
        //    Dictionary<int, List<major_change>> dic = new Dictionary<int, List<major_change>>();
        //    dic.Add(rows, list);
        //    return dic;
        //}
        #endregion
        public List<major_changeModel> Sel()
        {
            List<major_change> list = hr.major_Changes.ToList();
            List<major_changeModel> list1 = new List<major_changeModel>();
            foreach (major_change m in list)
            {
                major_changeModel ms = new major_changeModel()
                {
                    mch_id = m.mch_id,
                    first_kind_id = m.first_kind_id,
                    first_kind_name = m.first_kind_name,
                    second_kind_id = m.second_kind_id,
                    second_kind_name = m.second_kind_name,
                    third_kind_id = m.third_kind_id,
                    third_kind_name = m.third_kind_name,
                    major_id = m.major_id,
                    major_name = m.major_name,
                    major_kind_id = m.major_kind_id,
                    major_kind_name = m.major_kind_name,
                    new_first_kind_id = m.new_first_kind_id,
                    new_first_kind_name = m.new_first_kind_name,
                    new_second_kind_id = m.new_second_kind_id,
                    new_second_kind_name = m.new_second_kind_name,
                    new_third_kind_id = m.new_third_kind_id,
                    new_third_kind_name = m.new_third_kind_name,
                    new_major_id = m.new_major_id,
                    new_major_name = m.new_major_name,
                    new_major_kind_id = m.new_major_kind_id,
                    new_major_kind_name = m.new_major_kind_name,
                    human_id = m.human_id,
                    human_name = m.human_name,
                    salary_standard_id = m.salary_standard_id,
                    salary_standard_name = m.salary_standard_name,
                    salary_sum = m.salary_sum,
                    new_salary_standard_id = m.new_salary_standard_id,
                    new_salary_standard_name = m.new_salary_standard_name,
                    new_salary_sum = m.new_salary_sum,
                    change_reason = m.change_reason,
                    check_reason = m.check_reason,
                    check_status = m.check_status,
                    register = m.register,
                    checker = m.checker,
                    regist_time = m.regist_time,
                    check_time = m.check_time
                };
                list1.Add(ms);
            }
            return list1;
        }

        public major_changeModel SelById(int id)
        {
            major_change m = hr.Set<major_change>().AsNoTracking().Where(e => e.mch_id == id).FirstOrDefault();
            major_changeModel mm = new major_changeModel()
            {
                mch_id = m.mch_id,
                first_kind_id = m.first_kind_id,
                first_kind_name = m.first_kind_name,
                second_kind_id = m.second_kind_id,
                second_kind_name = m.second_kind_name,
                third_kind_id = m.third_kind_id,
                third_kind_name = m.third_kind_name,
                major_id = m.major_id,
                major_name = m.major_name,
                major_kind_id = m.major_kind_id,
                major_kind_name = m.major_kind_name,
                new_first_kind_id = m.new_first_kind_id,
                new_first_kind_name = m.new_first_kind_name,
                new_second_kind_id = m.new_second_kind_id,
                new_second_kind_name = m.new_second_kind_name,
                new_third_kind_id = m.new_third_kind_id,
                new_third_kind_name = m.new_third_kind_name,
                new_major_id = m.new_major_id,
                new_major_name = m.new_major_name,
                new_major_kind_id = m.new_major_kind_id,
                new_major_kind_name = m.new_major_kind_name,
                human_id = m.human_id,
                human_name = m.human_name,
                salary_standard_id = m.salary_standard_id,
                salary_standard_name = m.salary_standard_name,
                salary_sum = m.salary_sum,
                new_salary_standard_id = m.new_salary_standard_id,
                new_salary_standard_name = m.new_salary_standard_name,
                new_salary_sum = m.new_salary_sum,
                change_reason = m.change_reason,
                check_reason = m.check_reason,
                check_status = m.check_status,
                register = m.register,
                checker = m.checker,
                regist_time = m.regist_time,
                check_time = m.regist_time
            };
            return mm;
        }
       
        public async Task<int> Up(int id,major_changeModel m)
        {
            major_change mc = hr.Set<major_change>().AsNoTracking().Where(e => e.mch_id == id).FirstOrDefault();
            mc.check_status = m.check_status;
            mc.check_reason = m.check_reason;
            // mc = new major_change()
            //{
            //    mch_id = m.mch_id,
            //    first_kind_id = m.first_kind_id,
            //    first_kind_name = m.first_kind_name,
            //    second_kind_id = m.second_kind_id,
            //    second_kind_name = m.second_kind_name,
            //    third_kind_id = m.third_kind_id,
            //    third_kind_name = m.third_kind_name,
            //    major_id = m.major_id,
            //    major_name = m.major_name,
            //    major_kind_id = m.major_kind_id,
            //    major_kind_name = m.major_kind_name,
            //    new_first_kind_id = m.new_first_kind_id,
            //    new_first_kind_name = m.new_first_kind_name,
            //    new_second_kind_id = m.new_second_kind_id,
            //    new_second_kind_name = m.new_second_kind_name,
            //    new_third_kind_id = m.new_third_kind_id,
            //    new_third_kind_name = m.new_third_kind_name,
            //    new_major_id = m.new_major_id,
            //    new_major_name = m.new_major_name,
            //    new_major_kind_id = m.new_major_kind_id,
            //    new_major_kind_name = m.new_major_kind_name,
            //    human_id = m.human_id,
            //    human_name = m.human_name,
            //    salary_standard_id = m.salary_standard_id,
            //    salary_standard_name = m.salary_standard_name,
            //    salary_sum = m.salary_sum,
            //    new_salary_standard_id = m.new_salary_standard_id,
            //    new_salary_standard_name = m.new_salary_standard_name,
            //    new_salary_sum = m.new_salary_sum,
            //    change_reason = m.change_reason,
            //    check_reason = m.check_reason,
            //    check_status = m.check_status,
            //    register = m.register,
            //    checker = m.checker,
            //    regist_time = m.regist_time,
            //    check_time = m.check_time
            //};
            //hr.
            // hr.Database.ExecuteSqlCommand();
            string sql = $@"update major_change set check_status={m.check_status},check_reason='{m.check_reason}' where mch_id={m.mch_id} ";
            return hr.Database.ExecuteSqlCommand(sql);
            //hr.Entry(mc).State = EntityState.Unchanged;
            //hr.Entry(mc).State = EntityState.Modified;
            //return await hr.SaveChangesAsync();
        }
    }
}

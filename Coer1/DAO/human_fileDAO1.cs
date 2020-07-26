using System;
using System.Collections.Generic;
using System.Text;
using EFEntity;
using Model;
using IDAO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
   public class human_fileDAO1:Ihuman_fileDAO
    {
        private readonly TescDbContext tescDbContext;

        public human_fileDAO1(TescDbContext tescDbContext)
        {
            this.tescDbContext = tescDbContext;
        }


        //分页查询
        public DBFenYe<human_fileModel1> Fenye(int dqy, string tablename, string where, string keyname, int pagesize)
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
            var list = tescDbContext.hf.FromSqlRaw($@"exec proc_FenYe @pageSize,@keyName,@tabelName,@where,@currentPage,@rows out,@pages out", pt).ToList();
            DBFenYe<human_fileModel1> page = new DBFenYe<human_fileModel1>();
            page.li = new List<human_fileModel1>();
            foreach (var item in list)
            {
                human_fileModel1 sgm = new human_fileModel1()
                {
                    second_kind_id = item.second_kind_id,
                    second_kind_name = item.second_kind_name,
                    checker = item.checker,
                    check_status = item.check_status,
                    check_time = item.check_time,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    third_kind_id = item.third_kind_id,
                    third_kind_name = item.third_kind_name,
                    register = item.register,
                    regist_time = item.regist_time,
                    salary_standard_id = item.salary_standard_id,
                    salary_standard_name = item.salary_standard_name,
                    salary_sum = item.salary_sum,
                    delete_time = item.delete_time,
                    demand_salaray_sum = item.demand_salaray_sum,
                    changer = item.changer,
                    change_time = item.change_time,
                    file_chang_amount = item.file_chang_amount,
                    attachment_name = item.attachment_name,
                    bonus_amount = item.bonus_amount,
                    human_account = item.human_account,
                    human_address = item.human_address,
                    major_change_amount = item.major_change_amount,
                    huf_id = item.huf_id,
                    training_amount = item.training_amount,
                    vhuman_age = item.vhuman_age,
                    human_bank = item.human_bank,
                    human_birthday = item.human_birthday,
                    human_birthplace = item.human_birthplace,
                    human_educated_degree = item.human_educated_degree,
                    human_educated_major = item.human_educated_major,
                    human_educated_years = item.human_educated_years,
                    human_email = item.human_email,
                    human_family_membership = item.human_family_membership,
                    human_file_status = item.human_file_status,
                    human_histroy_records = item.human_histroy_records,
                    human_hobby = item.human_hobby,
                    human_id = item.human_id,
                    human_id_card = item.human_id_card,
                    human_major_id = item.human_major_id,
                    human_major_kind_id = item.human_major_kind_id,
                    human_major_kind_name = item.human_major_kind_name,
                    human_mobilephone = item.human_mobilephone,
                    human_name = item.human_name,
                    human_nationality = item.human_nationality,
                    human_party = item.human_party,
                    human_picture = item.human_picture,
                    human_postcode = item.human_postcode,
                    human_pro_designation = item.human_pro_designation,
                    human_qq = item.human_qq,
                    human_race = item.human_race,
                    human_religion = item.human_religion,
                    human_sex = item.human_sex,
                    human_society_security_id = item.human_society_security_id,
                    human_speciality = item.human_speciality,
                    human_telephone = item.human_telephone,
                    hunma_major_name = item.hunma_major_name,
                    lastly_change_time = item.lastly_change_time,
                    paid_salary_sum = item.paid_salary_sum,
                    recovery_time = item.recovery_time,
                    remark = item.remark
                };
                page.li.Add(sgm);
            }
            page.Pages = (int)pt[5].Value;
            page.Rows = (int)pt[6].Value;
            return page;
        }

        //查询
        public async Task<List<human_fileModel1>> Select()
        {
            List<human_file> list = await Task.Run(() => { return tescDbContext.hf.ToList(); });
            List<human_fileModel1> listm = new List<human_fileModel1>();

            foreach (human_file item in list)
            {
                human_fileModel1 sgm = new human_fileModel1()
                {                   
                    second_kind_id = item.second_kind_id,
                    second_kind_name = item.second_kind_name,                  
                    checker = item.checker,
                    check_status = item.check_status,
                    check_time = item.check_time,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,                  
                    third_kind_id = item.third_kind_id,
                    third_kind_name = item.third_kind_name,
                    register = item.register,
                    regist_time = item.regist_time,
                    salary_standard_id=item.salary_standard_id,
                    salary_standard_name=item.salary_standard_name,
                    salary_sum=item.salary_sum,
                    delete_time=item.delete_time,
                    demand_salaray_sum=item.demand_salaray_sum,
                    changer=item.changer,
                    change_time=item.change_time,
                    file_chang_amount=item.file_chang_amount,
                    attachment_name=item.attachment_name,
                    bonus_amount=item.bonus_amount,
                    human_account=item.human_account,
                    human_address=item.human_address,
                    major_change_amount=item.major_change_amount,
                    huf_id=item.huf_id,
                    training_amount=item.training_amount,
                    vhuman_age=item.vhuman_age,
                    human_bank=item.human_bank,
                    human_birthday=item.human_birthday,
                    human_birthplace=item.human_birthplace,
                    human_educated_degree=item.human_educated_degree,
                    human_educated_major=item.human_educated_major,
                    human_educated_years=item.human_educated_years,
                    human_email=item.human_email,
                    human_family_membership=item.human_family_membership,
                    human_file_status=item.human_file_status,
                    human_histroy_records=item.human_histroy_records,
                    human_hobby=item.human_hobby,
                    human_id=item.human_id,
                    human_id_card=item.human_id_card,
                    human_major_id=item.human_major_id,
                    human_major_kind_id=item.human_major_kind_id,
                    human_major_kind_name=item.human_major_kind_name,
                    human_mobilephone=item.human_mobilephone,
                    human_name=item.human_name,
                    human_nationality=item.human_nationality,
                    human_party=item.human_party,
                    human_picture=item.human_picture,
                    human_postcode=item.human_postcode,
                    human_pro_designation=item.human_pro_designation,
                    human_qq=item.human_qq,
                    human_race=item.human_race,
                    human_religion=item.human_religion,
                    human_sex=item.human_sex,
                    human_society_security_id=item.human_society_security_id,
                    human_speciality=item.human_speciality,
                    human_telephone=item.human_telephone,
                    hunma_major_name=item.hunma_major_name,
                    lastly_change_time=item.lastly_change_time,
                    paid_salary_sum=item.paid_salary_sum,
                    recovery_time=item.recovery_time,
                    remark=item.remark
                };
                listm.Add(sgm);
            }

            return listm;
        }

        //复核
        public async Task<int> Update(human_fileModel1 hfm)
        {
            human_file fh = new human_file()
            {
                huf_id=hfm.huf_id,
                paid_salary_sum = hfm.paid_salary_sum,
                salary_sum=hfm.salary_sum,
                register=hfm.register,
                check_status=hfm.check_status,
                check_time=hfm.check_time
            };
            tescDbContext.hf.Attach(fh);
            tescDbContext.Entry(fh).Property(p => p.paid_salary_sum).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.salary_sum).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.register).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.check_status).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.check_time).IsModified = true;
            return await tescDbContext.SaveChangesAsync();
        }

        //登记
        public async Task<int> Denji(human_fileModel1 hfm)
        {
            human_file fh = new human_file()
            {
                huf_id = hfm.huf_id,
                paid_salary_sum = hfm.paid_salary_sum,
                salary_sum = hfm.salary_sum,
                register = hfm.register,
                check_status = hfm.check_status,
                regist_time=hfm.regist_time
            };
            tescDbContext.hf.Attach(fh);
            tescDbContext.Entry(fh).Property(p => p.paid_salary_sum).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.salary_sum).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.register).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.check_status).IsModified = true;
            tescDbContext.Entry(fh).Property(p => p.regist_time).IsModified = true;
            return await tescDbContext.SaveChangesAsync();
        }
    }
}

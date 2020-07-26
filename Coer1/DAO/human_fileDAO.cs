using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EFEntity;
using IDAO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAO
{
    public class human_fileDAO : Ihuman_fileDAO
    {
        private readonly TescDbContext tescDbContext;
        public human_fileDAO(TescDbContext tescDbContext)
        {
            this.tescDbContext = tescDbContext;

        }

        public List<human_fileModel> FenYe(FenYeModel fen)
        {
            List<human_fileModel> list = new List<human_fileModel>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = tescDbContext.human_Files.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                human_fileModel h = new human_fileModel()
                {
                    
                    huf_id = ad.huf_id,
                    human_id = ad.human_id,
                    first_kind_id = ad.first_kind_id,
                    first_kind_name = ad.first_kind_name,
                    second_kind_id = ad.second_kind_id,
                    second_kind_name = ad.second_kind_name,
                    third_kind_id = ad.third_kind_id,
                    third_kind_name = ad.third_kind_name,
                    human_name = ad.human_name,
                    human_address = ad.human_address,
                    human_postcode = ad.human_postcode,
                    human_pro_designation = ad.human_pro_designation,
                    human_major_kind_id = ad.human_major_kind_id,
                    human_major_kind_name = ad.human_major_kind_name,
                    human_major_id = ad.human_major_id,
                    hunma_major_name = ad.hunma_major_name,
                    human_telephone = ad.human_telephone,
                    human_mobilephone = ad.human_mobilephone,
                    human_bank = ad.human_bank,
                    human_account = ad.human_account,
                    human_qq = ad.human_qq,
                    human_email = ad.human_email,
                    human_hobby = ad.human_hobby,
                    human_speciality = ad.human_speciality,
                    human_sex = ad.human_sex,
                    human_religion = ad.human_religion,
                    human_party = ad.human_party,
                    human_nationality = ad.human_nationality,
                    human_race = ad.human_race,
                    human_birthday = ad.human_birthday,
                    human_birthplace = ad.human_birthplace,
                    vhuman_age = ad.vhuman_age,
                    human_educated_degree = ad.human_educated_degree,
                    human_educated_years = ad.human_educated_years,
                    human_educated_major = ad.human_educated_major,
                    human_society_security_id = ad.human_society_security_id,
                    human_id_card = ad.human_id_card,
                    remark = ad.remark,
                    salary_standard_id = ad.salary_standard_id,
                    salary_standard_name = ad.salary_standard_name,
                    salary_sum = ad.salary_sum,
                    demand_salaray_sum = ad.demand_salaray_sum,
                    paid_salary_sum = ad.paid_salary_sum,
                    major_change_amount = ad.major_change_amount,
                    bonus_amount = ad.bonus_amount,
                    training_amount = ad.training_amount,
                    file_chang_amount = ad.file_chang_amount,
                    human_histroy_records = ad.human_histroy_records,
                    human_family_membership = ad.human_family_membership,
                    human_picture = ad.human_picture,
                    attachment_name = ad.attachment_name,
                    check_status = ad.check_status,
                    register = ad.register,
                    checker = ad.checker,
                    changer = ad.changer,
                    regist_time = ad.regist_time,
                    check_time = ad.check_time,
                    change_time = ad.change_time,
                    lastly_change_time = ad.lastly_change_time,
                    delete_time = ad.delete_time,
                    recovery_time = ad.recovery_time,
                    human_file_status = ad.human_file_status
                };
                list.Add(h);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public Dictionary<int, List<human_fileModel>> Fenyehm(int currepage, int pagesize, string firstname, string secondname, string thirdname, DateTime ktime, DateTime endtime)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<human_fileModel>> FenyeHMOne(int currepage, int pagesize, DateTime ktime, DateTime endtime)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<human_fileModel>> Fenyercx(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<human_fileModel>> Fenyercx2(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<human_fileModel>> Fenyercx3(int currepage, int pagesize, string fl1, string fl2, string fl3, string fl4, string fl5)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> FindFisrt(string firstid)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> Findhfd(int id)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> FindHUmanid(string id)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> FindIdName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> FindSecond(string seconed)
        {
            throw new NotImplementedException();
        }

        public List<human_fileModel> Findt(string thrid)
        {
            throw new NotImplementedException();
        }

        public int HREdit(human_fileModel h)
        {
            throw new NotImplementedException();
        }

        public int human_fileAdd(human_fileModel h)
        {
            throw new NotImplementedException();
        }

        public int human_fileDelete(human_fileModel h)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<human_fileModel>> human_fileFenye(int currepage, int pagesize)
        {
            throw new NotImplementedException();
        }

        public int human_fileUpdate(human_fileModel h)
        {
            throw new NotImplementedException();
        }

        public human_fileModel human_fileUpdateSelect(int id)
        {
            throw new NotImplementedException();
        }

        public human_fileModel SelByID02(int id)
        {
            List<human_file> item1 = tescDbContext.human_Files.Where(e => e.huf_id == id).ToList();
            human_file h = item1[0];
            human_fileModel model = new human_fileModel()
            {
                huf_id = id,
                human_id = h.human_id,
                first_kind_id = h.first_kind_id,
                first_kind_name = h.first_kind_name,
                second_kind_id = h.second_kind_id,
                second_kind_name = h.second_kind_name,
                third_kind_id = h.third_kind_id,
                third_kind_name = h.third_kind_name,
                human_name = h.human_name,
                human_address = h.human_address,
                human_postcode = h.human_postcode,
                human_pro_designation = h.human_pro_designation,
                human_major_kind_id = h.human_major_kind_id,
                human_major_kind_name = h.human_major_kind_name,
                human_major_id = h.human_major_id,
                hunma_major_name = h.hunma_major_name,
                human_telephone = h.human_telephone,
                human_mobilephone = h.human_mobilephone,
                human_bank = h.human_bank,
                human_account = h.human_account,
                human_qq = h.human_qq,
                human_email = h.human_email,
                human_hobby = h.human_hobby,
                human_speciality = h.human_speciality,
                human_sex = h.human_sex,
                human_religion = h.human_religion,
                human_party = h.human_party,
                human_nationality = h.human_nationality,
                human_race = h.human_race,
                human_birthday = h.human_birthday,
                human_birthplace = h.human_birthplace,
                vhuman_age = h.vhuman_age,
                human_educated_degree = h.human_educated_degree,
                human_educated_years = h.human_educated_years,
                human_educated_major = h.human_educated_major,
                human_society_security_id = h.human_society_security_id,
                human_id_card = h.human_id_card,
                //v = h.v,
                salary_standard_id = h.salary_standard_id,
                salary_standard_name = h.salary_standard_name,
                salary_sum = h.salary_sum,
                demand_salaray_sum = h.demand_salaray_sum,
                paid_salary_sum = h.paid_salary_sum,
                major_change_amount = h.major_change_amount,
                bonus_amount = h.bonus_amount,
                training_amount = h.training_amount,
                file_chang_amount = h.file_chang_amount,
                human_histroy_records = h.human_histroy_records,
                human_family_membership = h.human_family_membership,
                human_picture = h.human_picture,
                attachment_name = h.attachment_name,
                check_status = h.check_status,
                register = h.register,
                checker = h.checker,
                changer = h.changer,
                regist_time = h.regist_time,
                check_time = h.check_time,
                change_time = h.change_time,
                lastly_change_time = h.lastly_change_time,
                delete_time = h.delete_time,
                recovery_time = h.recovery_time,
                human_file_status = h.human_file_status
            };
            return model;
        }

        public List<human_fileModel> select()
        {
            List<human_fileModel> list2 = new List<human_fileModel>();
            List<human_file> list = tescDbContext.human_Files.ToList();
            foreach (human_file item in list)
            {
                human_fileModel tm = new human_fileModel()
                {
                    attachment_name = item.attachment_name,
                    bonus_amount = item.bonus_amount,
                    changer = item.changer,
                    change_time = item.change_time,
                    checker = item.checker,
                    check_status = item.check_status,
                    check_time = item.check_time,
                    delete_time = item.delete_time,
                    demand_salaray_sum = item.demand_salaray_sum,
                    file_chang_amount = item.file_chang_amount,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    huf_id = item.huf_id,
                    human_account = item.human_account,
                    human_address = item.human_address,
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
                    major_change_amount = item.major_change_amount,
                    paid_salary_sum = item.paid_salary_sum,
                    recovery_time = item.recovery_time,
                    register = item.register,
                    regist_time = item.regist_time,
                    remark = item.remark,
                    salary_standard_id = item.salary_standard_id,
                    salary_standard_name = item.salary_standard_name,
                    salary_sum = item.salary_sum,
                    second_kind_id = item.second_kind_id,
                    second_kind_name = item.second_kind_name,
                    third_kind_id = item.third_kind_id,
                    third_kind_name = item.third_kind_name,
                    training_amount = item.training_amount,
                };
                list2.Add(tm);
            }
            return list2;
        }
    }
}

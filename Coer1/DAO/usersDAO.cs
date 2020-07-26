using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class usersDAO : IusersDAO
    {
        private readonly TescDbContext tesc;
        public usersDAO(TescDbContext tesc) {
            this.tesc = tesc;
        }

        public int DL(usersModel ff)
        {
            int a = 0;
            List<users> list = tesc.users.ToList();
            foreach (users item in list)
            {
                if (ff.User_name == item.user_name && ff.User_password == item.user_password)
                {
                    a = 1;
                }
            }
            return a;
        }

        public async Task<int> Login(usersModel us)
        {
            int a = 0;
            List<usersModel> list = new List<usersModel>();
            List<users> list2 = await Task.Run(() => { return tesc.users.ToList(); });
            foreach (users item in list2)
            {
                if (us.User_name == item.user_name && us.User_password == item.user_password)
                {
                    a = 1;
                }
            }

            return a;
        }
        public int sfcz(usersModel bjm)
        {
            int a = 0;
            List<users> list = tesc.users.ToList();
            foreach (users item in list)
            {
                if (bjm.User_name == item.user_name)
                {
                    a = 1;
                }
            }
            return a;
        }
        public async Task<int> Add(users t)
        {
            tesc.Set<users>().Add(t);
            return tesc.SaveChanges();
        }

        public async Task<int> UserCreate(usersModel bjm)
        {
            if (sfcz(bjm) == 1)
            {
                return 0;
            }
            else
            {
                users us = new users()
                {
                    user_id = bjm.User_id,
                    user_name = bjm.User_name,
                    user_true_name = bjm.User_true_name,
                    user_password = bjm.User_password,
                    user_identity = bjm.user_identity
                };
                return await Add(us);
            }
        }

        public async Task<int> UserDelete(int id)
        {
            users aa = await tesc.users.FindAsync(id);
            tesc.users.Remove(aa);
            return await tesc.SaveChangesAsync();
        }

        public async Task<int> UserEdit(usersModel bjm)
        {
            users us = new users()
            {
                user_id = bjm.User_id,
                user_name = bjm.User_name,
                user_password = bjm.User_password,
                user_true_name = bjm.User_true_name,
                user_identity = bjm.user_identity
            };
            tesc.Attach(us);
            tesc.Entry(us).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await tesc.SaveChangesAsync();
        }

        public usersModel UserSelectBy(int id)
        {
            users us2 = null;
            List<users> us = tesc.users.ToList();    //eo->dto
            foreach (users item in us)
            {
                if (item.user_id == id)
                {
                    us2 = item;
                };
            }
            usersModel um = new usersModel()
            {
                User_id = id,
                User_name = us2.user_name,
                User_true_name = us2.user_true_name,
                User_password = us2.user_password,
                user_identity = us2.user_identity
            };
            return um;
        }

        public List<usersModel> FenYe(FenYeModel fen)
        {
            List<usersModel> list = new List<usersModel>();
            //int PageSize = fen.PageSize;
            //string KeyName = fen.KeyName;
            //string Table = fen.TableName;
            //string Where = fen.Where;
            //int CurrentPage = fen.CurrentPage;
            
            //SqlParameter[] ps = {
            //        //new SqlParameter(){ParameterName="@pageSize",Value=PageSize},
            //        //   new SqlParameter(){ParameterName="@keyName",Value=KeyName},
            //        //   new SqlParameter(){ParameterName="@tableName",Value=KeyName},
            //        //   new SqlParameter(){ParameterName="@where",Value=Where},
            //        //   new SqlParameter(){ParameterName="@currentPage",Value=CurrentPage},
            //           new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
            //           new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},

            //    };
            SqlParameter[] ps ={
            new SqlParameter() {ParameterName= "@pageSize",Value=fen.PageSize },
                new SqlParameter() { ParameterName = "@keyName", Value = fen.KeyName },
                    new SqlParameter() { ParameterName = "@tableName", Value = fen.TableName },
                        new SqlParameter() { ParameterName = "@where", Value = fen.Where },
                            new SqlParameter() { ParameterName = "@currentPage", Value = fen.CurrentPage },
                                new SqlParameter() { ParameterName = "@rows", Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                                    new SqlParameter() { ParameterName = "@pages", Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int },
                                        };
            var sql = tesc.users.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                usersModel h = new usersModel()
                {
                    User_id=ad.user_id,
                    User_true_name=ad.user_true_name,
                    user_identity=ad.user_identity,
                    User_name=ad.user_name,
                    User_password=ad.user_password
                };
                list.Add(h);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public string Ro(usersModel us)
        {
            string a = "";
            List<usersModel> list = new List<usersModel>();
            List<users> list2 = tesc.users.ToList();
            foreach (users item in list2)
            {
                if (us.User_name == item.user_name && us.User_password == item.user_password)
                {
                    a = item.user_identity;
                }
            }
            return a;
        }
    }
}

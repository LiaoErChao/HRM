using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class roleDAO : IroleDAO
    {
        private readonly TescDbContext1 qx;
        public roleDAO(TescDbContext1 qx) 
        {
            this.qx = qx;
        }
        public async Task<int> ADD(roleModel bjm)
        {
            role a = new role() 
            {
                user_identity = bjm.user_identity,
                r_status = bjm.r_status,
                r_sm=bjm.r_sm 
            };
            qx.Roles.Add(a);
            return await qx.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            role aa = await qx.Roles.FindAsync(id);
            qx.Roles.Remove(aa);
            return await qx.SaveChangesAsync();
        }

        public List<roleModel> FenYe(FenYeModel fen)
        {
            List<roleModel> list = new List<roleModel>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = qx.Roles.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var ad in sql)
            {
                roleModel h = new roleModel()
                {
                    r_id=ad.r_id,
                    r_sm=ad.r_sm,
                    r_status=ad.r_status,
                    user_identity=ad.user_identity
                };
                list.Add(h);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }


        public async Task<List<roleModel>> RoleSelect()
        {
            List<roleModel> list = new List<roleModel>();
            List<role> list1 = await Task.Run(() => { return qx.Roles.ToList(); });
            foreach (role item in list1)
            {
                roleModel um = new roleModel()
                {
                    r_id = item.r_id,
                    user_identity = item.user_identity,
                    r_sm=item.r_sm
                };
                list.Add(um);
            }
            return list;
        }

        public async Task<roleModel> Select(int id)
        {
            role a = await qx.Roles.FindAsync(id);
            roleModel b = new roleModel()
            {
                r_id = a.r_id,
                user_identity = a.user_identity,
                r_sm=a.r_sm,
                r_status = a.r_status
            };
            return b;
        }

        public async Task<int> Update(roleModel rb)
        {
            role us = new role()
            {
                r_id=rb.r_id,
                r_sm=rb.r_sm,
                user_identity=rb.user_identity,
                r_status=rb.r_status
            };
            qx.Roles.Attach(us);
            qx.Entry(us).Property(p => p.r_sm).IsModified = true;
            qx.Entry(us).Property(p => p.r_status).IsModified = true;
            return await qx.SaveChangesAsync();
        }
    }
}

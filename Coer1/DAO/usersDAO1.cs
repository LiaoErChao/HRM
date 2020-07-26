 using System;
using System.Collections.Generic;
using System.Text;
using Model;
using EFEntity;
using IDAO;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class usersDAO1 : IusersDAO
    {
        private readonly TescDbContext tescDbContext;
        public usersDAO1(TescDbContext tescDbContext) {
            this.tescDbContext = tescDbContext;
        }

        public async Task<int> Login(usersModel1 u)
        {
            int a = 0;
            List<usersModel1> list = new List<usersModel1>();
            List<users> list2 = await Task.Run(() => { return tescDbContext.u.ToList(); });
            foreach (users item in list2)
            {
                if (u.user_name == item.user_name && u.user_password == item.user_password) {
                    a = 1;
                }
            }

            return a;
        }
    }
}

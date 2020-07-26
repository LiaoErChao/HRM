using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using IBLL;
using System.Threading.Tasks;

namespace BLL
{
    public class usersBLL1 : IuserBLL
    {
        private readonly IusersDAO iud;
        public usersBLL1(IusersDAO iud) {
            this.iud = iud;
        }

        //登录 
        public Task<int> Login(usersModel1 u)
        {
            return iud.Login(u);
        }
    }
}

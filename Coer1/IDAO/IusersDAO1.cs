using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface IusersDAO1
    {
        //登录
        Task<int> Login(usersModel1 u);
    }
}

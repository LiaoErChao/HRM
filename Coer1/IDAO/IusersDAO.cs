using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface IusersDAO
    {
        Task<int> Login(usersModel us);
        int DL(usersModel ff);
        List<usersModel> FenYe(FenYeModel fen);
        Task<int> UserCreate(usersModel bjm);
        Task<int> UserDelete(int id);
        usersModel UserSelectBy(int id);
        Task<int> UserEdit(usersModel bjm);
        string Ro(usersModel us);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class usersBLL:IusersBLL
    {
        private readonly IusersDAO iusersDAO;
        public usersBLL(IusersDAO iusersDAO) 
        {
            this.iusersDAO = iusersDAO;
        }

        public int DL(usersModel ff)
        {
            return iusersDAO.DL(ff);
        }

        public List<usersModel> FenYe(FenYeModel fen)
        {
            return iusersDAO.FenYe(fen);
        }


        public Task<int> Login(usersModel us)
        {
            return iusersDAO.Login(us);
        }

        public string Ro(usersModel us)
        {
            return iusersDAO.Ro(us);
        }

        public Task<int> UserCreate(usersModel bjm)
        {
            return iusersDAO.UserCreate(bjm);
        }

        public Task<int> UserDelete(int id)
        {
            return iusersDAO.UserDelete(id);
        }

        public Task<int> UserEdit(usersModel bjm)
        {
            return iusersDAO.UserEdit(bjm);
        }

        public usersModel UserSelectBy(int id)
        {
            return iusersDAO.UserSelectBy(id);
        }
    }
}

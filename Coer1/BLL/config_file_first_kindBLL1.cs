using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;
namespace BLL
{
    public class config_file_first_kindBLL1 : Iconfig_file_first_kindBLL1
    {
        private readonly Iconfig_file_first_kindDAO1 iconfig_File_First_KindDAO;
        public config_file_first_kindBLL1(Iconfig_file_first_kindDAO1 iconfig_File_First_KindDAO)
        {
            this.iconfig_File_First_KindDAO = iconfig_File_First_KindDAO;

        }

        //添加
        public Task<int> Add(config_file_first_kindModel1 cffk)
        {
            return iconfig_File_First_KindDAO.Add(cffk);
        }


        //删除
        public Task<int> Delete(int id)
        {
            return iconfig_File_First_KindDAO.Delete(id);
        }


        //查询所有
        public Task<List<config_file_first_kindModel1>> SelectAll()
        {
            return iconfig_File_First_KindDAO.SelectAll();
        }


        //修改
        public Task<int> Update(config_file_first_kindModel1 cffkm)
        {
            return iconfig_File_First_KindDAO.Update(cffkm);
        }


        //修改查询
        public Task<config_file_first_kindModel1> UpSelect(int id)
        {
            return iconfig_File_First_KindDAO.UpSelect(id);
        }
    }
}

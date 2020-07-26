using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using System.Threading.Tasks;
using IDAO;
namespace BLL
{
    public class config_file_third_kindBLL : Iconfig_file_third_kindBLL
    {
        private readonly Iconfig_file_third_kindDAO icftkd;
        public config_file_third_kindBLL(Iconfig_file_third_kindDAO icftkd) {
            this.icftkd = icftkd;

        }

        public Task<int> ADD(config_file_third_kindModel cftkm)
        {
            return icftkd.ADD(cftkm);
        }

        //删除
        public Task<int> Delete(int id)
        {
            return icftkd.Delete(id);
        }

        //查询
        public Task<List<config_file_third_kindModel>> Select()
        {
            return icftkd.Select();
        }

        //二级机构查询
        public Task<List<config_file_second_kindModel>> SelectErJiJG()
        {
            return icftkd.SelectErJiJG();
        }

        public List<config_file_third_kindModel> Selectt()
        {
            return icftkd.Selectt();
        }

        //一级机构查询
        public Task<List<config_file_first_kindModel>> SelectYiJiJG()
        {
            return icftkd.SelectYiJiJG();
        }

        //修改
        public Task<int> Update(config_file_third_kindModel cftkm)
        {
            return icftkd.Update(cftkm);
        }

        //修改
        public Task<config_file_third_kindModel> UpSelect(int id)
        {
            return icftkd.UpSelect(id);
        }
    }
}

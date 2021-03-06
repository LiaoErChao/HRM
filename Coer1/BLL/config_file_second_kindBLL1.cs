﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class config_file_second_kindBLL1 : Iconfig_file_second_kindBLL1
    {
        private readonly Iconfig_file_second_kindDAO1 iconfig;
        private readonly Iconfig_file_second_kindDAO icfskd;

        public config_file_second_kindBLL1(Iconfig_file_second_kindDAO1 iconfig, Iconfig_file_second_kindDAO icfskd) {
            this.iconfig = iconfig;
            this.icfskd = icfskd;
        }



        //添加
        public Task<int> ADD(config_file_second_kindModel1 cffskm)
        {
            return iconfig.ADD(cffskm);
        }

        //删除
        public Task<int> Delete(int id)
        {
            return iconfig.Delete(id);
        }

        //查询
        public Task<List<config_file_second_kindModel1>> Load()
        {
            return iconfig.Load();
        }

        public List<config_file_second_kindModel1> Loads()
        {
            return icfskd.Loads();
        }


        //一级机构查询
        public Task<List<config_file_first_kindModel1>> SelectYiJiJG()
        {
            return iconfig.SelectYiJiJG();
        }


        //修改查询
        public Task<config_file_second_kindModel1> Up(int id)
        {
            return iconfig.Up(id);
        }

        //修改
        public Task<int> Update(config_file_second_kindModel1 cffskm)
        {
            return iconfig.Update(cffskm);
        }
    }
}

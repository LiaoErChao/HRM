﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Iconfig_file_first_kindDAO
    {

        //查询所有
        Task<List<config_file_first_kindModel1>> SelectAll();

        List<config_file_first_kindModel1> Selects();

        //添加
        Task<int> Add(config_file_first_kindModel1 cffk);

        //修改查询
        Task<config_file_first_kindModel1> UpSelect(int id);

        //修改
        Task<int> Update(config_file_first_kindModel1 cffkm);

        //删除
        Task<int> Delete(int id);
      
    }
}

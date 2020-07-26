﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using System.Threading.Tasks;

namespace IBLL
{
   public interface Iconfig_file_first_kindBLL
    {       
        //查询所有
        Task<List<config_file_first_kindModel1>> SelectAll();

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

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Iconfig_major_kindDAO1
    {
        //查询   
        Task<List<config_major_kindModel1>> Load();

        //删除
        Task<int> Delete(int id);

        //添加    
        Task<int> Add(config_major_kindModel1 cmm);
    }
}

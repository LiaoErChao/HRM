﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface Iconfig_public_charBLL
    {
        //查询所有
        Task<List<config_public_charModel>> SelectAll();

        //添加    
        Task<int> Add(config_public_charModel cpcm);
        
        //条件
        Task<config_public_charModel> WhereSelect(int id);

        //删除
        Task<int> Delete(int id);
    }
}
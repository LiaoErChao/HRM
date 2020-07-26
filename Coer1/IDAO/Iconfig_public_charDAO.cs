﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
   public interface Iconfig_public_charDAO
    {
        //查询所有
        Task<List<config_public_charModel1>> SelectAll();

        //添加    
        Task<int> Add(config_public_charModel1 cpcm);

        //条件查询
        Task<config_public_charModel1> WhereSelect(int id);

        //删除
        Task<int> Delete(int id);
    }
}

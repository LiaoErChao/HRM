using System;
using System.Collections.Generic;
using System.Text;

namespace EFEntity
{
    public class Quan
    {
        public int id { get; set; }//主键
        public string text { get; set; }//可访问页面
        public string QuanURL { get; set; }//页面路径
        public int Pid { get; set; }//父子级id
        public string state { get; set; }//父子级
    }
}

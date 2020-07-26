using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Model
{
    public class usersModel
    {
        public int User_id { get; set; }//主键
        public string User_name { get; set; }//用户名
        public string User_true_name { get; set; }//真实姓名
        public string User_password { get; set; }//密码
        public string user_identity { get; set; }//用户身份
    }
}

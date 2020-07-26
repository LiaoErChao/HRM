using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 用户表
     * 
     */
    public class users
    {
        [Key]
        public int user_id { get; set; }//主键
        public string user_name { get; set; }//用户名
        public string user_true_name { get; set; }//真实姓名
        public string user_password { get; set; }//密码
        public string user_identity { get; set; }//用户身份
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{

    /**
     * 用户表
     * 
     */
    public class usersModel1
    {
        public int user_id { get; set; }//主键

       
        
        [Required(ErrorMessage = "名字不能为空")]
        public string user_name { get; set; }//用户名
        
        
        public string user_true_name { get; set; }//真实姓名
       
        
        
        [Required(ErrorMessage = "密码不能为空")]
        public string user_password { get; set; }//密码

    }
}

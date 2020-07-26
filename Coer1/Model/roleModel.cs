using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class roleModel
    {
        [Key]
        public int r_id { get; set; }//角色id
        public string user_identity { get; set; }//角色名称(用户身份)
        public string r_sm { get; set; }//角色说明
        public int r_status { get; set; }//角色状态
    }
}

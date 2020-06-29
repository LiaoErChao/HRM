using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     * 关键字设置，包括人力资源管理，薪酬发放，激励管理，调动管理，薪酬标准，培训
     * 
     */
    public class config_primary_key
    {
        [Key]
        public int prk_id { get; set; }//主键
        public string primary_key_table { get; set; }//关键字所涉及的数据库表名
        public string primary_key { get; set; }//关键字
        public string key_name { get; set; }//中文关键字
        public string primary_key_status { get; set; }//是否为关键字

    }
}

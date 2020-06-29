using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     *  职位分类设置
     */
    public class config_major_kind
    {

        [Key]
        public int mfk_id { get; set; }//主键
        public string major_kind_id { get; set; }//职位分类编号
        public string major_kind_name { get; set; }//职分类位名称
    }
}

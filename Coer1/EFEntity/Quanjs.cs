using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFEntity
{
    public class Quanjs
    {
        [Key]
        public int id { get; set; }//id  主键
        public int Qid { get; set; }//用户id
        public int Jid { get; set; } //  父级为0   子机值为父级ID
    }
}

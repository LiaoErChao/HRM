using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /**
    * 试题题库登记表
    * 
    */
    public class engage_subjectsModel
    {
        public int sub_id { get; set; }//主键
        public string first_kind_id { get; set; }//试题I级分类编号
        public string first_kind_name { get; set; }//试题I级分类名称 

        public string second_kind_id { get; set; }//试题II级分类编号
        public string second_kind_name { get; set; }//试题II级分类名称 
        public string register { get; set; }//登记人
        public DateTime regist_time { get; set; }//登记时间
        public string derivation { get; set; }//试题出处
        public string content { get; set; }//题干
        public string key_a { get; set; }//答案a
        public string key_b { get; set; }//答案b 
        public string key_c { get; set; }//答案c
        public string key_d { get; set; }//答案d
        public string key_e { get; set; }//答案e
        public string correct_key { get; set; }//正确答案 
        public string changer { get; set; }//变更人
        public DateTime change_time { get; set; }//变更时间
    }
}

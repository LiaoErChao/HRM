﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    /**
     *  考试答题详细信息 
     * 
     */
    public class engage_answer_details
    {
        [Key]
        public int and_id { get; set; }//答案详细信息
        public string answer_number { get; set; }//答案编号
        public int subject_id { get; set; }//试题编号
        public string answer { get; set; }//答题者答案

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
     public class About
    {
        [Key] //Id için birincil anahtar eklendi.
        public int AboutID { get; set; }

        [StringLength(1000)] //Karakter uzunluğu belirleme.
        public string AboutDetails1{ get; set; }

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get;  set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }
        
    }
}

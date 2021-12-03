﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretMvc.Models.Sınıflar
{
    public class Yapilacak
    {

        [Key]
        public int YapilacakId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string baslik{ get; set; }
        [Column(TypeName = "bit")]
        public bool durum { get; set; }
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretMvc.Models.Sınıflar
{
    public class Sepet
    {
        [Key] 
        public int SepetId { get; set; }
        
        public int UrunId { get; set; }
       
        public int CariId { get; set; }
        //[Column(TypeName = "Varchar")]
        //[StringLength(30)]
        //public string UrunAd { get; set; }

        public int Adet { get; set; }
        //public string UrunGorsel { get; set; }
        //public decimal Fiyat { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
    }
}
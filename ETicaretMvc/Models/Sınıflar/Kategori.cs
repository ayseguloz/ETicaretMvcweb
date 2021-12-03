using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaretMvc.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoryId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; } // her bir kategoride birden fazla ürün alabilir, o yüzden interface kullanıyoruz.
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.Models
{

    [Table("tb_Kitap")]
    public class Kitap
    {

        public int KitapId { get; set; }

        [Required]
        public string KitapAdi { get; set; }

        [Required]
        public double KitapFiyat { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }


        [ForeignKey("KitapDetay")]
        public int KitapDetayId { get; set; }
        public KitapDetay KitapDetay { get; set; }

        [ForeignKey("YayınEvi")]
        public int YayınEviId { get; set; }
        public YayınEvi YayınEvi  { get;set;}

        public ICollection<KitapYazar>KitapYazarlar
        {
            get;set;
            
        }
    }
}

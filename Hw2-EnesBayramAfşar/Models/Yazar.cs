using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.Models
{
    [Table("tb_Yazar")]
    public class Yazar
    {
        [Key]
        public int Yazar_Id { get; set; }

        [Required]
        public string YazarAd { get; set; }

        [Required]
        public string YazarSoyad { get; set; }

        
        public string Adres { get; set; }

        
        public DateTime DogumTarihi { get; set; }

        [NotMapped]
        public string AdSoyad { get { return $"{YazarAd} {YazarSoyad}"; } }

        public ICollection<KitapYazar> KitapYazarlar
        {
            get; set;

        }

    }
}

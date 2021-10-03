using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.Models
{
    public class KitapDetay
    {

        public int KitapDetayId { get; set; }

        [Required]
        public int BolumSayisi { get; set; }

        public int KitapSayfasi { get; set; }

        public double KitapAgirlik { get; set; }

        public Kitap Kitap {get; set;}//entity olarak ekledik
    }
}

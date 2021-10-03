using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.Models
{
    public class KitapYazar
    {
        //çoktan çoka ilişki

        [ForeignKey("Kitap")]
        public int KitapId { get; set; }

        [ForeignKey("Yazar")]
        public int Yazar_Id { get; set; }

        public Kitap Kitap { get; set; }

        public Yazar Yazar { get; set; }
    }
}

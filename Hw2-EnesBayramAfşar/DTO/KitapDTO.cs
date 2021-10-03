using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.DTO
{
    public class KitapDTO
    {

        public int KitapId { get; set; }

     
        public string KitapAdi { get; set; }

      
        public double KitapFiyat { get; set; }


        public string ISBN { get; set; }

      
        public int KategoriId { get; set; }
       


      
        public int KitapDetayId { get; set; }
       

    
        public int YayınEviId { get; set; }
      

     
    }
}

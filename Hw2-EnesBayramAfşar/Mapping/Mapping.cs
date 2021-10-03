using AutoMapper;
using Hw2_EnesBayramAfşar.DTO;
using Hw2_EnesBayramAfşar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {

            CreateMap<Kategori, KategoriDTO>();
            CreateMap<KitapDetay, KitapDetayDTO>();
            CreateMap<Kitap, KitapDTO>();
            CreateMap<Tur, TurDTO>();
            CreateMap<YayınEvi, YayinEviDTO>();
            CreateMap<Yazar, YazarDTO>();

        }
    }
}

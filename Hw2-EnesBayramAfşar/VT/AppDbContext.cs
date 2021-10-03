using Hw2_EnesBayramAfşar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw2_EnesBayramAfşar.VT
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                    
        }

        public DbSet<Models.Kategori> Kategoriler { get; set; }
        public DbSet<Models.Tur> Turler { get; set; }
        public DbSet<Models.Kitap> Kitaplar { get; set; }
        public DbSet<Models.YayınEvi> YayınEvleri { get; set; }
        public DbSet<Models.Yazar> Yazarlar { get; set; }

        public DbSet<Models.KitapYazar> KitapYazarlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<KitapYazar>().HasKey(x => new { x.Yazar_Id, x.KitapId });
        }

        public DbSet<Hw2_EnesBayramAfşar.Models.KitapDetay> KitapDetay { get; set; }



    }
}

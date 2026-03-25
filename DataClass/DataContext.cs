using StudentEduApp.DataClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace StudentEduProject.DataClass
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<EgitimModul> EgitimModulleri  => Set<EgitimModul>(); 
        public DbSet<Performans> Performanslar  => Set<Performans>();
        public DbSet<Ogrenci> Ogrenciler  => Set<Ogrenci>();

        public DbSet<EgitimKayit> EgitimKayitlari => Set<EgitimKayit>();
    }
}

//ef core kur ,design paketi kur , migrations ekle 
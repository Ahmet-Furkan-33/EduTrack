using System.ComponentModel.DataAnnotations;
using StudentEduProject.DataClass;

namespace StudentEduApp.DataClass
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? Bolum { get; set; }
        public string? AktiflikDurumu { get; set; }

        public ICollection<EgitimKayit> EgitimKayitlari{get;set;} = new List<EgitimKayit>();
    }
}
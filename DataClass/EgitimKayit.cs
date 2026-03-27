using System.ComponentModel.DataAnnotations;
using StudentEduProject.DataClass;

namespace StudentEduApp.DataClass //KursKayit.cs entity sınıfını tanımlar.
{
    public class EgitimKayit
    {

     [Key] //KayitId birincil anahtar olarak tanımlanmıştır.
     public int KayitId { get; set; }
     public int OgrenciId { get; set; } //Yabancı anahtar olarak OgrenciId tanımlanmıştır.
     public Ogrenci Ogrenci {get; set;} = null!; //öğrenciler tablosundaki öğrencilere erişmeyi sağlar(join işlemleri)
     public int EgitimModulId{ get; set; }
     public EgitimModul EgitimModul{get; set;} = null!; //Kurslar tablosundaki kurslara erişmeyi sağlar(join)
     public DateTime KayitTarihi { get; set; }

    }
}
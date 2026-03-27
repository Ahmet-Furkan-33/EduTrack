using System.ComponentModel.DataAnnotations;
using StudentEduApp.DataClass;

namespace StudentEduProject.DataClass
{
    public class EgitimModul
    {
        
        public int EgitimModulId { get; set; }
        public string? ModulAdi { get; set; }
        public int Sure { get; set; }
        public string? Seviye { get; set; }

        public ICollection<EgitimKayit> EgitimKayitlari {get; set;} = new List<EgitimKayit>();
    }
}

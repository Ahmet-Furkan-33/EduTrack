using System.ComponentModel.DataAnnotations;
using StudentEduProject.DataClass;

namespace StudentEduApp.DataClass
{
    
    public class Egitmen
    {
        [Key]
        public int EgitmenId { get; set; }
        public string? AdSoyad { get; set; }
        [EmailAddress]
        public string? Eposta { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = false)]
        public DateTime BaslamaTarihi { get; set; }

        public ICollection<EgitimModul> EgitimModulleri {get; set;} = new List<EgitimModul>();
    }
}
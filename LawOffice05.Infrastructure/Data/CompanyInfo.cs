using System.ComponentModel.DataAnnotations;

namespace LawOffice05.Infrastructure.Data
{
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfLaw { get; set; }

        [Required]
        [StringLength(1000)]
        public string InfoAboutLaw { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice05.Infrastructure.Data
{
    public class Instance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeOfInstance { get; set; }

        [Required]
        [StringLength(30)]
        public string CaseNumberByTheInstance { get; set; }

        [Required]
        public DateTime CaseNumberDate { get; set; }

        [StringLength(30)]
        public string Session { get; set; }

        public DateTime SessionDate { get; set; }

        [Required]
        [ForeignKey(nameof(Case))]
        public int CaseId { get; set; }

        [Required]
        public Case Case { get; set; }

        public ICollection<OutsideDocument> OutsideDocuments { get; set; } = new List<OutsideDocument>();

        public ICollection<InsideDocument> InsideDocuments { get; set; } = new List<InsideDocument>();
    }
}

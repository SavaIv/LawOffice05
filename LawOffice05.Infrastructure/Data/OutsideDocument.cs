using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice05.Infrastructure.Data
{
    public class OutsideDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeOfTheDocument { get; set; }

        [StringLength(30)]
        public string OriginalNumberOfTheDocument { get; set; }

        public DateTime OriginalDateOfTheDocument { get; set; }

        public string TheDocumentInfo { get; set; }

        public string TheDocument { get; set; }

        [Required]
        [ForeignKey(nameof(Instance))]
        public int InstanceId { get; set; }

        [Required]
        public Instance Instance { get; set; }
    }
}

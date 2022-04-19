using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice05.Infrastructure.Data
{
    public class InsideDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeOfTheDocument { get; set; }

        [Required]
        public DateTime DateOfCreating { get; set; }

        [StringLength(30)]
        public string CompanyOutGoingNumber { get; set; }

        [StringLength(50)]
        public string RecipientЕntranceNumber { get; set; }

        public string TheDocumentInfo { get; set; }

        public string TheDocument { get; set; }

        [Required]
        [ForeignKey(nameof(Instance))]        
        public int InstanceId { get; set; }

        [Required]
        public Instance Instance { get; set; }
    }
}

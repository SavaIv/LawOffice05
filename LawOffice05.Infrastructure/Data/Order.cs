using LawOffice05.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice05.Infrastructure.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string ProblemType { get; set; }

        [Required]
        [StringLength(30)]
        public string UrgencyType { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeOfAnswer { get; set; }

        [Required]
        [StringLength(160)]
        public string ProblemDescription { get; set; }

        [Required]
        [StringLength(30)]
        public string StatusOfTheOrder { get; set; }

        [Required]
        [ForeignKey(nameof(User))]        
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public string? FeedBack { get; set; }
    }
}

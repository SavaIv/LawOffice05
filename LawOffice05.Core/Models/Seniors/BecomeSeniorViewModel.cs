using System.ComponentModel.DataAnnotations;

namespace LawOffice05.Core.Models.Seniors
{
    public class BecomeSeniorViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Current empolyee position")]
        public string Position { get; set; }
    }
}

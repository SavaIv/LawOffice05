using System.ComponentModel.DataAnnotations;

namespace LawOffice05.Infrastructure.Data
{
    public class OrderProblemType
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string ProblemType { get; set; }
    }
}

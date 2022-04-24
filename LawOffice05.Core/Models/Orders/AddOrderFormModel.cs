using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LawOffice05.Core.Models.Orders
{
    public class AddOrderFormModel
    {
        //[MaxLength(100)]
        //public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [Display(Name = "Problem Type")]
        public string ProblemType { get; init; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [Display(Name = "Urgency Type")]
        public string UrgencyType { get; init; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [Display(Name = "Answer Type")]
        public string TypeOfAnswer { get; init; }

        [Required]        
        [StringLength(160, MinimumLength = 5, ErrorMessage = "You must put a message with numbert of charakters between 5 and 160")]
        //[StringLength(160, MinimumLength = 5)]
        [Display(Name = "Description of the Problem")]
        public string ProblemDescription { get; init; }

        [BindNever]
        public IEnumerable<OredrProblemTypeViewModel>? ProblemTypeNames { get; set; }
    }
}

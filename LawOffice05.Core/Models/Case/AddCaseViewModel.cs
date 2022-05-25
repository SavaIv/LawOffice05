using LawOffice05.Core.Models.Orders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Models.Case
{
    public class AddCaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [Display(Name = "Inside Case Number")]
        public string InsideCaseNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Inside Case Name")]
        public string InsideCaseName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Display(Name = "Client First Name")]
        public string ClientFirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Display(Name = "Client Middle Name")]
        public string ClientMiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Display(Name = "Client Famili Name")]
        public string ClientFamiliName { get; set; }

        [Required]
        [MaxLength(60)]
        [MinLength(2)]
        [Display(Name = "Client Adrress")]
        public string ClientAdrress { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(10)]
        [Display(Name = "Client ID")]
        public string ClientID { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [Display(Name = "Case Description")]
        public string CaseDescription { get; set; }

        [BindNever]
        public IEnumerable<CaseDescriptionViewModel>? CaseDescriptionNames { get; set; }
    }
}

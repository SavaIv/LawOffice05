using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Models.Orders
{
    public class AddOrderFormModel
    {
        //public int Id { get; set; }

        [Display(Name = "Problem Type")]
        public string ProblemType { get; set; }

        [Display(Name = "Urgency Type")]
        public string UrgencyType { get; set; }

        [Display(Name = "Answer Type")]
        public string TypeOfAnswer { get; set; }

        [Display(Name = "Description of the Problem")]
        public string ProblemDescription { get; set; }

        [Display(Name = "Status")]
        public string StatusOfTheOrder { get; set; } = "Pending";

        public string UserId { get; set; }

        [Display(Name = "Client Name")]
        public string UserName { get; set; }

        [Display(Name = "FeedBack")]
        public string? FeedBack { get; set; }
    }
}

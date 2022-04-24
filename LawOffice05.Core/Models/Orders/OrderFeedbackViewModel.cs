using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Models.Orders
{
    public class OrderFeedbackViewModel
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Write/Edit FeedBack")]
        [StringLength(30)]
        public string FeedBack { get; set; }
    }
}

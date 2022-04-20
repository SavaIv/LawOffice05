using System.ComponentModel.DataAnnotations;

namespace LawOffice05.Core.Models.Orders
{
    public class AddOrderFormModel
    {
        //public int Id { get; set; }

        //[Display(Name = "Problem Type")]
        public string ProblemType { get; set; }

        //[Display(Name = "Urgency Type")]
        public string UrgencyType { get; set; }

        //[Display(Name = "Answer Type")]
        public string TypeOfAnswer { get; set; }
        
        //[Display(Name = "Description of the Problem")]
        public string ProblemDescription { get; set; }

        

        

        
    }
}

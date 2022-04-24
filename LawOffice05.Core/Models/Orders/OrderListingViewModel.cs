namespace LawOffice05.Core.Models.Orders
{
    public class OrderListingViewModel
    {       
        public int OrderId { get; set; }

        public string ProblemType { get; set; }

        public string UrgencyType { get; set; }
                
        public string TypeOfAnswer { get; set; }

        public string ProblemDescription { get; set; }

        public string StatusOfTheOrder { get; set; }

        public string UserName { get; set; }

        public string? FeedBack { get; set; }
    }
}

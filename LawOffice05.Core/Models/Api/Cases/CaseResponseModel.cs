namespace LawOffice05.Core.Models.Api.Cases
{
    public class CaseResponseModel
    {
        public int CaseId { get; set; }

        public string InsideCaseNumber { get; set; }

        public string InsideCaseName { get; set; }

        public string ClientName { get; set; }

        public string CaseDescription { get; set; }

        public string SupervisorName { get; set; }
    }
}

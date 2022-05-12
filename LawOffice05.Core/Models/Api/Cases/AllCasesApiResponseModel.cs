namespace LawOffice05.Core.Models.Api.Cases
{
    public class AllCasesApiResponseModel
    {
        public int CurrentPage { get; set; }

        public int TotalCases { get; set; }

        public IEnumerable<CaseResponseModel> Cases { get; set; }
    }
}

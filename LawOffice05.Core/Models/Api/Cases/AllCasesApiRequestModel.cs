using LawOffice05.Core.Models.Enumerations;

namespace LawOffice05.Core.Models.Api.Cases
{
    public class AllCasesApiRequestModel
    {
        public string CaseDescription { get; set; }
        
        public string SearchTerm { get; set; }
        
        public CaseSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;
        
        public int CasesPerPage { get; set; } = 10;

        public int TotalCases { get; set; }

        

        

        // това е от cars app-a:
        //public string Brand { get; init; }
        //public string SearchTerm { get; init; }
        //public CarSorting Sorting { get; init; }
        // int CurrentPage { get; init; } = 1;
        //public int CarsPerPage { get; init; } = 10;
    }
}

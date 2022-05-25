using LawOffice05.Core.Models.Case;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LawOffice05.Core.Services.Cases
{
    public class CaseServiceModel
    {        
        public int CaseId { get; set; }
                
        public string InsideCaseNumber { get; set; }
                
        public string InsideCaseName { get; set; }
                
        public string ClientFirstName { get; set; }
                
        public string ClientMiddleName { get; set; }
                
        public string ClientFamiliName { get; set; }
                
        public string ClientAdrress { get; set; }
                
        public string ClientID { get; set; }
                
        public string CaseDescription { get; set; }

        public string SeniorId { get; set; }

        [BindNever]
        public IEnumerable<CaseDescriptionViewModel>? CaseDescriptionNames { get; set; }
    }
}

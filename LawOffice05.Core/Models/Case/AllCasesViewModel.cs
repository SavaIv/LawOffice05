using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Models.Case
{
    public class AllCasesViewModel
    {
        public int CaseId { get; set; }

        public string InsideCaseNumber { get; set; }
                
        public string InsideCaseName { get; set; }
                
        public string ClientName { get; set; }       
                      
        public string CaseDescription { get; set; }

        public string SupervisorName { get; set; }
    }
}

using LawOffice05.Core.Models.Case.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Models.Case
{
    public class AllCasesQueryModel
    {
        // всички cases, които ще визуализираме (модела, който ще заменим в AllCases)
        public IEnumerable<AllCasesViewModel> Cases { get; set; }

        // това ще ни е нужно, когато ще търсим по CaseDescription
        [Display(Name = "Case Description")]
        public string CaseDescription { get; set; }

        // това ще ни е нужно, когато ще търсим по CaseDescription
        public IEnumerable<string> CaseDescriptions { get; set; }

        // това ще ни е нужно, когато ще търсим по текс (независимо къде)
        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        // тази еномерация ще ни е нужна за сортирането
        public CaseSorting Sorting { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice05.Core.Services.Seniors
{
    public interface ISeniorService
    {
        // check is the current user is a senior
        public bool IsSenior(string userId);
    }
}

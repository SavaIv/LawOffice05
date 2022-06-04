using LawOffice05.Infrastructure.Data;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace LawOffice05.Core.Services.Cases
{
    public class CaseService : ICaseService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public CaseService(ApplicationDbContext _data, IMapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        public IEnumerable<CaseServiceModel> ByUser(string userId)
        {
            var result = data.Cases
                .Where(c => c.Senior.UserId == userId)
                .Select(c => new CaseServiceModel
                {
                    CaseDescription = c.CaseDescription,
                    ClientAdrress = c.ClientAdrress,
                    ClientFamiliName = c.ClientFamiliName,
                    ClientID = c.ClientID,
                    ClientFirstName = c.ClientFirstName,
                    ClientMiddleName = c.ClientMiddleName,
                    InsideCaseName = c.InsideCaseName,
                    InsideCaseNumber = c.InsideCaseNumber,
                    CaseId = c.Id
                })
                .ToList();

            return result;
        }

        public CaseServiceModel Details(int caseId)
        {
            var result = data.Cases
                .Where(c => c.Id == caseId)
                .ProjectTo<CaseServiceModel>(mapper.ConfigurationProvider)
                //.Select(c => new CaseServiceModel
                //{
                //    CaseDescription = c.CaseDescription,
                //    ClientID = c.ClientID,
                //    CaseId = c.Id,
                //    ClientAdrress = c.ClientAdrress,
                //    ClientFamiliName = c.ClientFamiliName,
                //    ClientFirstName = c.ClientFirstName,
                //    ClientMiddleName = c.ClientMiddleName,
                //    InsideCaseName = c.InsideCaseName,
                //    InsideCaseNumber = c.InsideCaseNumber,
                //    SeniorId = c.Senior.UserId
                //})
                .FirstOrDefault();

            return result;
        }

        public bool Edit(
            int caseId, 
            string insideCaseNumber, 
            string insideCaseName, 
            string clientFirstName, 
            string clientMiddleName, 
            string clientFamiliName, 
            string clientAdrress, 
            string clientID, 
            string caseDescription, 
            int seniorId)
        {
            var theCase = data.Cases.Find(caseId);

            // check: Are we have rights to edit? -> only the senior thet is creatorof the case can edit the case.
            if(theCase.SeniorId != seniorId)
            {
                return false;
            }

            // as a genaral - we will overWrite everyThing
            theCase.InsideCaseNumber = insideCaseNumber;
            theCase.InsideCaseName = insideCaseName;
            theCase.ClientFirstName = clientFirstName;
            theCase.ClientMiddleName = clientMiddleName;
            theCase.ClientFamiliName = clientFamiliName;
            theCase.ClientAdrress = clientAdrress;
            theCase.ClientID = clientID;
            theCase.CaseDescription = caseDescription;
            //theCase.SeniorId = seniorId;       // no necessary to edit the senior   

            data.SaveChanges();

            return true;
        }
    }
}

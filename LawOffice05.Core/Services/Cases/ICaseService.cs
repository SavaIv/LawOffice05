namespace LawOffice05.Core.Services.Cases
{
    public interface ICaseService
    {
        IEnumerable<CaseServiceModel> ByUser(string userId);

        CaseServiceModel Details(int caseId);

        // if we reurn "false" - means that we have no rights to edit the case
        bool Edit(
               int caseId,
               string insideCaseNumber,
               string insideCaseName,
               string clientFirstName,
               string clientMiddleName,
               string clientFamiliName,
               string clientAdrress,
               string clientID,
               string caseDescription,
               int seniorId);
    }
}

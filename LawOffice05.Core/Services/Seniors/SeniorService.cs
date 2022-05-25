using LawOffice05.Infrastructure.Data;

namespace LawOffice05.Core.Services.Seniors
{
    public class SeniorService : ISeniorService
    {
        private readonly ApplicationDbContext data;

        public SeniorService(ApplicationDbContext _data)
        {
            data = _data;
        }

        public bool IsSenior(string userId)
        {
            bool result = data.Seniors.Any(s => s.UserId == userId);

            return result;
        }
    }
}

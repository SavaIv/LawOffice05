using AutoMapper;
using LawOffice05.Core.Models.Orders;
using LawOffice05.Core.Services.Cases;
using LawOffice05.Infrastructure.Data;

namespace LawOffice05.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderListingViewModel>();

            CreateMap<Case, CaseServiceModel>()
                .ForMember(csm => csm.SeniorId, config => config.MapFrom(c => c.Senior.UserId))
                .ForMember(csm => csm.CaseId, config => config.MapFrom(c => c.Id));
        }
    }
}

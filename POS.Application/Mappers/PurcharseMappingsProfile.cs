using AutoMapper;
using POS.Application.Dtos.Purcharse.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class PurcharseMappingsProfile : Profile
    {
        public PurcharseMappingsProfile()
        {
            CreateMap<Purcharse, PurcharseResponseDto>()
                .ForMember(x => x.PurcharseId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Provider, x => x.MapFrom(y => y.Provider!.Name))
                .ForMember(x => x.Warehouse, x => x.MapFrom(y => y.Warehouse!.Name))
                .ForMember(x => x.DateOffPurcharse, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();
                
        }
    }
}

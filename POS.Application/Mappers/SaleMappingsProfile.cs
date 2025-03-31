﻿using AutoMapper;
using POS.Application.Dtos.Sale.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class SaleMappingsProfile : Profile
    {
        public SaleMappingsProfile()
        {
            CreateMap<Sale, SaleResponseDto>()
                .ForMember(x => x.SaleId, x=> x.MapFrom(y => y.Id))
                .ForMember(x => x.VoucherDescription, x=> x.MapFrom(y => y.VoucherDocumentType.Description))
                .ForMember(x => x.Client, x=> x.MapFrom(y => y.Client.Name))
                .ForMember(x => x.Warehouse, x=> x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.DateofSale, x=> x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap()
                ;
        }
    }
}

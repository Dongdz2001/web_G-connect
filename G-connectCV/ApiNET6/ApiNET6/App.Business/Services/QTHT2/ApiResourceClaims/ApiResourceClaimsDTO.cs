using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiResourceClaimsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Type { get; set; }
        public int ApiResourceId { get; set; }
        public string ten_ApiResourceId { get; set; }
    }
    public class ApiResourceClaimsProfile : Profile
    {
        public ApiResourceClaimsProfile()
        {
            CreateMap<ApiResourceClaims, ApiResourceClaimsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.Type))
                ;
            CreateMap<ApiResourceClaims, ApiResourceClaimsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.Type))

                .ForMember(x => x.ten_ApiResourceId, otp => otp.MapFrom(y => y.ApiResources_ApiResourceId.Name))
                ;
            CreateMap<ApiResourceClaimsDTO, ApiResourceClaims>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiResources_ApiResourceId, otp => otp.Ignore());
        }
    }
    public class ApiResourceClaimsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


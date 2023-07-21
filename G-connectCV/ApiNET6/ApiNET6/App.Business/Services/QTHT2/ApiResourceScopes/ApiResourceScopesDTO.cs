using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiResourceScopesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Scope { get; set; }
        public int ApiResourceId { get; set; }
        public string ten_ApiResourceId { get; set; }
    }
    public class ApiResourceScopesProfile : Profile
    {
        public ApiResourceScopesProfile()
        {
            CreateMap<ApiResourceScopes, ApiResourceScopesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiResourceScopes, ApiResourceScopesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ApiResourceId, otp => otp.MapFrom(y => y.ApiResources_ApiResourceId.id))
                ;
            CreateMap<ApiResourceScopesDTO, ApiResourceScopes>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiResources_ApiResourceId, otp => otp.Ignore());
        }
    }
    public class ApiResourceScopesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


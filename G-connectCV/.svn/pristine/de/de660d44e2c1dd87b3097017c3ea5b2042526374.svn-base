using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiScopePropertiesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ScopeId { get; set; }
        public string ten_ScopeId { get; set; }
    }
    public class ApiScopePropertiesProfile : Profile
    {
        public ApiScopePropertiesProfile()
        {
            CreateMap<ApiScopeProperties, ApiScopePropertiesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiScopeProperties, ApiScopePropertiesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ScopeId, otp => otp.MapFrom(y => y.ApiScopes_ScopeId.id))
                ;
            CreateMap<ApiScopePropertiesDTO, ApiScopeProperties>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiScopes_ScopeId, otp => otp.Ignore());
        }
    }
    public class ApiScopePropertiesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiScopeClaimsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Type { get; set; }
        public int ScopeId { get; set; }
        public string ten_ScopeId { get; set; }
    }
    public class ApiScopeClaimsProfile : Profile
    {
        public ApiScopeClaimsProfile()
        {
            CreateMap<ApiScopeClaims, ApiScopeClaimsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiScopeClaims, ApiScopeClaimsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ScopeId, otp => otp.MapFrom(y => y.ApiScopes_ScopeId.id))
                ;
            CreateMap<ApiScopeClaimsDTO, ApiScopeClaims>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiScopes_ScopeId, otp => otp.Ignore());
        }
    }
    public class ApiScopeClaimsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


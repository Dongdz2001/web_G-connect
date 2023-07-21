using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class IdentityResourceClaimsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Type { get; set; }
        public int IdentityResourceId { get; set; }
        public string ten_IdentityResourceId { get; set; }
    }
    public class IdentityResourceClaimsProfile : Profile
    {
        public IdentityResourceClaimsProfile()
        {
            CreateMap<IdentityResourceClaims, IdentityResourceClaimsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<IdentityResourceClaims, IdentityResourceClaimsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_IdentityResourceId, otp => otp.MapFrom(y => y.IdentityResources_IdentityResourceId.id))
                ;
            CreateMap<IdentityResourceClaimsDTO, IdentityResourceClaims>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.IdentityResources_IdentityResourceId, otp => otp.Ignore());
        }
    }
    public class IdentityResourceClaimsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


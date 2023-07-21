using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class IdentityResourcePropertiesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int IdentityResourceId { get; set; }
        public string ten_IdentityResourceId { get; set; }
    }
    public class IdentityResourcePropertiesProfile : Profile
    {
        public IdentityResourcePropertiesProfile()
        {
            CreateMap<IdentityResourceProperties, IdentityResourcePropertiesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<IdentityResourceProperties, IdentityResourcePropertiesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_IdentityResourceId, otp => otp.MapFrom(y => y.IdentityResources_IdentityResourceId.id))
                ;
            CreateMap<IdentityResourcePropertiesDTO, IdentityResourceProperties>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.IdentityResources_IdentityResourceId, otp => otp.Ignore());
        }
    }
    public class IdentityResourcePropertiesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


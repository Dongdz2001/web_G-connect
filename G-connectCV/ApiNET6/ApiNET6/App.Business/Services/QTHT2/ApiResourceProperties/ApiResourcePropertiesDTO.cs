using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiResourcePropertiesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ApiResourceId { get; set; }
        public string ten_ApiResourceId { get; set; }
    }
    public class ApiResourcePropertiesProfile : Profile
    {
        public ApiResourcePropertiesProfile()
        {
            CreateMap<ApiResourceProperties, ApiResourcePropertiesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiResourceProperties, ApiResourcePropertiesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ApiResourceId, otp => otp.MapFrom(y => y.ApiResources_ApiResourceId.id))
                ;
            CreateMap<ApiResourcePropertiesDTO, ApiResourceProperties>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiResources_ApiResourceId, otp => otp.Ignore());
        }
    }
    public class ApiResourcePropertiesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


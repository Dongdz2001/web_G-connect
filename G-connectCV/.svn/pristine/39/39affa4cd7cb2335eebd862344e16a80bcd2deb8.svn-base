using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiResourceSecretsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
        public int ApiResourceId { get; set; }
        public string ten_ApiResourceId { get; set; }
    }
    public class ApiResourceSecretsProfile : Profile
    {
        public ApiResourceSecretsProfile()
        {
            CreateMap<ApiResourceSecrets, ApiResourceSecretsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiResourceSecrets, ApiResourceSecretsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ApiResourceId, otp => otp.MapFrom(y => y.ApiResources_ApiResourceId.id))
                ;
            CreateMap<ApiResourceSecretsDTO, ApiResourceSecrets>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.ApiResources_ApiResourceId, otp => otp.Ignore());
        }
    }
    public class ApiResourceSecretsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


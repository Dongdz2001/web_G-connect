using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ApiScopesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
    }
    public class ApiScopesProfile : Profile
    {
        public ApiScopesProfile()
        {
            CreateMap<ApiScopes, ApiScopesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ApiScopes, ApiScopesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                ;
            CreateMap<ApiScopesDTO, ApiScopes>()
                .IncludeBase<BaseDTOInt, BaseModelInt>();
        }
    }
    public class ApiScopesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


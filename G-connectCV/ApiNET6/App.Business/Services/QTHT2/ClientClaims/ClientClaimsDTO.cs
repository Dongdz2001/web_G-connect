using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ClientClaimsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int ClientId { get; set; }
        public string ten_ClientId { get; set; }
    }
    public class ClientClaimsProfile : Profile
    {
        public ClientClaimsProfile()
        {
            CreateMap<ClientClaims, ClientClaimsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ClientClaims, ClientClaimsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ClientId, otp => otp.MapFrom(y => y.Clients_ClientId.id))
                ;
            CreateMap<ClientClaimsDTO, ClientClaims>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.Clients_ClientId, otp => otp.Ignore());
        }
    }
    public class ClientClaimsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


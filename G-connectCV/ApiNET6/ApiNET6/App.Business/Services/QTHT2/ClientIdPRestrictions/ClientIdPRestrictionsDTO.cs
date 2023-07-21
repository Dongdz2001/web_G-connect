using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ClientIdPRestrictionsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Provider { get; set; }
        public int ClientId { get; set; }
        public string ten_ClientId { get; set; }
    }
    public class ClientIdPRestrictionsProfile : Profile
    {
        public ClientIdPRestrictionsProfile()
        {
            CreateMap<ClientIdPRestrictions, ClientIdPRestrictionsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ClientIdPRestrictions, ClientIdPRestrictionsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ClientId, otp => otp.MapFrom(y => y.Clients_ClientId.id))
                ;
            CreateMap<ClientIdPRestrictionsDTO, ClientIdPRestrictions>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.Clients_ClientId, otp => otp.Ignore());
        }
    }
    public class ClientIdPRestrictionsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


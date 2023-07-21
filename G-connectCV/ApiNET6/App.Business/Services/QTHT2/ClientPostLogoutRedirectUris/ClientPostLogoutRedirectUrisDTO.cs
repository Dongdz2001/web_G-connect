using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ClientPostLogoutRedirectUrisDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public int ClientId { get; set; }
        public string ten_ClientId { get; set; }
    }
    public class ClientPostLogoutRedirectUrisProfile : Profile
    {
        public ClientPostLogoutRedirectUrisProfile()
        {
            CreateMap<ClientPostLogoutRedirectUris, ClientPostLogoutRedirectUrisSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ClientPostLogoutRedirectUris, ClientPostLogoutRedirectUrisDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ClientId, otp => otp.MapFrom(y => y.Clients_ClientId.id))
                ;
            CreateMap<ClientPostLogoutRedirectUrisDTO, ClientPostLogoutRedirectUris>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.Clients_ClientId, otp => otp.Ignore());
        }
    }
    public class ClientPostLogoutRedirectUrisSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class ClientCorsOriginsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        //public int Id { get; set; }
        public string Origin { get; set; }
        public int ClientId { get; set; }
        public string ten_ClientId { get; set; }
    }
    public class ClientCorsOriginsProfile : Profile
    {
        public ClientCorsOriginsProfile()
        {
            CreateMap<ClientCorsOrigins, ClientCorsOriginsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<ClientCorsOrigins, ClientCorsOriginsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                .ForMember(x => x.ten_ClientId, otp => otp.MapFrom(y => y.Clients_ClientId.id))
                ;
            CreateMap<ClientCorsOriginsDTO, ClientCorsOrigins>()
                .IncludeBase<BaseDTOInt, BaseModelInt>()
                .ForMember(x => x.Clients_ClientId, otp => otp.Ignore());
        }
    }
    public class ClientCorsOriginsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


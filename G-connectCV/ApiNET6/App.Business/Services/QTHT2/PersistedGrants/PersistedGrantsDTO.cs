using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class PersistedGrantsDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        public string Key { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string SessionId { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public DateTime? ConsumedTime { get; set; }
        public string Data { get; set; }
    }
    public class PersistedGrantsProfile : Profile
    {
        public PersistedGrantsProfile()
        {
            CreateMap<PersistedGrants, PersistedGrantsSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.Key))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))
                ;
            CreateMap<PersistedGrants, PersistedGrantsDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.id))

                ;
            CreateMap<PersistedGrantsDTO, PersistedGrants>()
                .IncludeBase<BaseDTOInt, BaseModelInt>();
        }
    }
    public class PersistedGrantsSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


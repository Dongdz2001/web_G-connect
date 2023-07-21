using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class DeviceCodesDTO : BaseDTOInt
    {
        public int value { get; set; }
        public string label { get; set; }

        public string UserCode { get; set; }
        public string DeviceCode { get; set; }
        public string SubjectId { get; set; }
        public string SessionId { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime Expiration { get; set; }
        public string Data { get; set; }
    }
    public class DeviceCodesProfile : Profile
    {
        public DeviceCodesProfile()
        {
            CreateMap<DeviceCodes, DeviceCodesSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.UserCode))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.Description))
                ;
            CreateMap<DeviceCodes, DeviceCodesDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.Description))

                ;
            CreateMap<DeviceCodesDTO, DeviceCodes>()
                .IncludeBase<BaseDTOInt, BaseModelInt>();
        }
    }
    public class DeviceCodesSelectDTO
    {
        public int value { get; set; }
        public string label { get; set; }
    }
}


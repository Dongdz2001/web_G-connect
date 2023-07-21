using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;

namespace App.Business.Services.QTHT
{
    public class ChucVuDTO : BaseDTO
    {
        public string ma { get; set; }
        public string ten { get; set; }
        public string mo_ta { get; set; }
        public Guid value { get; set; }
        public string label { get; set; }
    }
    public class ChucVuProfile : Profile
    {
        public ChucVuProfile()
        {
            CreateMap<chuc_vu, ChucVuDTO>()
            .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
            .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten));
            CreateMap<ChucVuDTO, chuc_vu>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class ChucVuSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}

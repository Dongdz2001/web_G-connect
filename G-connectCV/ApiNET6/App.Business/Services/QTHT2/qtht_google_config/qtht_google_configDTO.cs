using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_google_configDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string email { get; set; }
        public string refresh_token { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_google_configProfile : Profile
    {
        public qtht_google_configProfile()
        {
            CreateMap<google_config, qtht_google_configSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.email))
                ;
            CreateMap<google_config, qtht_google_configDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.email))

                ;
            CreateMap<qtht_google_configDTO, google_config>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_google_configSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


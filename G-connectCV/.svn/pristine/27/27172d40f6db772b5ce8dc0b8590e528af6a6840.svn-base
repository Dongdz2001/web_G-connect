using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_chuc_vuDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string mo_ta { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_chuc_vuProfile : Profile
    {
        public qtht_chuc_vuProfile()
        {
            CreateMap<chuc_vu, qtht_chuc_vuSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<chuc_vu, qtht_chuc_vuDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))

                ;
            CreateMap<qtht_chuc_vuDTO, chuc_vu>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_chuc_vuSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


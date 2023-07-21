using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_cau_hinh_maDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string gia_tri { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_cau_hinh_maProfile : Profile
    {
        public qtht_cau_hinh_maProfile()
        {
            CreateMap<cau_hinh_ma, qtht_cau_hinh_maSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<cau_hinh_ma, qtht_cau_hinh_maDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))

                ;
            CreateMap<qtht_cau_hinh_maDTO, cau_hinh_ma>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_cau_hinh_maSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


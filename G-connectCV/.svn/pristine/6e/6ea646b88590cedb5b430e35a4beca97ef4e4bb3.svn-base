using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nhom_nguoi_dungDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_nhom_nguoi_dungProfile : Profile
    {
        public qtht_nhom_nguoi_dungProfile()
        {
            CreateMap<nhom_nguoi_dung, qtht_nhom_nguoi_dungSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<nhom_nguoi_dung, qtht_nhom_nguoi_dungDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))

                ;
            CreateMap<qtht_nhom_nguoi_dungDTO, nhom_nguoi_dung>()
                .ForMember(x => x.ds_nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.ds_dieu_huong, otp => otp.Ignore())
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_nhom_nguoi_dungSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


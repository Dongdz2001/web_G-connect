using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nhom_nguoi_dung_2_dieu_huongDTO 
    {
        public Guid value { get; set; }
        public string label { get; set; }

        public Guid nhom_nguoi_dung_id { get; set; }
        public string ten_nhom_nguoi_dung_id { get; set; }
        public Guid dieu_huong_id { get; set; }
        public string ten_dieu_huong_id { get; set; }
    }
    public class qtht_nhom_nguoi_dung_2_dieu_huongProfile : Profile
    {
        public qtht_nhom_nguoi_dung_2_dieu_huongProfile()
        {
            CreateMap<nhom_nguoi_dung_2_dieu_huong, qtht_nhom_nguoi_dung_2_dieu_huongSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.nhom_nguoi_dung_id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.nhom_nguoi_dung.ten))
                ;
            CreateMap<nhom_nguoi_dung_2_dieu_huong, qtht_nhom_nguoi_dung_2_dieu_huongDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.nhom_nguoi_dung_id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.nhom_nguoi_dung.ten))

                .ForMember(x => x.ten_nhom_nguoi_dung_id, otp => otp.MapFrom(y => y.nhom_nguoi_dung.ten))
                .ForMember(x => x.ten_dieu_huong_id, otp => otp.MapFrom(y => y.dieu_huong.ten))
                ;
            CreateMap<qtht_nhom_nguoi_dung_2_dieu_huongDTO, nhom_nguoi_dung_2_dieu_huong>()
                //.IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.nhom_nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.dieu_huong, otp => otp.Ignore())
                .ForMember(x => x.nhom_nguoi_dung_id, otp => otp.Ignore())
                .ForMember(x => x.dieu_huong_id, otp => otp.Ignore());
        }
    }
    public class qtht_nhom_nguoi_dung_2_dieu_huongSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


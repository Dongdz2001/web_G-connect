using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nguoi_dung_2_nhom_nguoi_dungDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        public Guid nguoi_dung_id { get; set; }
        public string ten_nguoi_dung_id { get; set; }
        public Guid nhom_nguoi_dung_id { get; set; }
        public string ten_nhom_nguoi_dung_id { get; set; }
    }
    public class qtht_nguoi_dung_2_nhom_nguoi_dungProfile : Profile
    {
        public qtht_nguoi_dung_2_nhom_nguoi_dungProfile()
        {
            CreateMap<nguoi_dung_2_nhom_nguoi_dung, qtht_nguoi_dung_2_nhom_nguoi_dungSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.nguoi_dung_id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.nhom_nguoi_dung.ten))
                ;
            CreateMap<nguoi_dung_2_nhom_nguoi_dung, qtht_nguoi_dung_2_nhom_nguoi_dungDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.nhom_nguoi_dung_id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.nhom_nguoi_dung.ten))

                .ForMember(x => x.ten_nguoi_dung_id, otp => otp.MapFrom(y => y.nguoi_dung.ten))
                .ForMember(x => x.ten_nhom_nguoi_dung_id, otp => otp.MapFrom(y => y.nhom_nguoi_dung.ten))
                ;
            CreateMap<qtht_nguoi_dung_2_nhom_nguoi_dungDTO, nguoi_dung_2_nhom_nguoi_dung>()
                //.IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.nhom_nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.nhom_nguoi_dung_id, otp => otp.Ignore());
        }
    }
    public class qtht_nguoi_dung_2_nhom_nguoi_dungSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


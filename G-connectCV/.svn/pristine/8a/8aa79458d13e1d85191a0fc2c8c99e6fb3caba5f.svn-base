using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nhat_ky_he_thong_loaiDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string hanh_dong { get; set; }
        public string ten_hanh_dong { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_nhat_ky_he_thong_loaiProfile : Profile
    {
        public qtht_nhat_ky_he_thong_loaiProfile()
        {
            CreateMap<nhat_ky_he_thong_loai, qtht_nhat_ky_he_thong_loaiSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.hanh_dong))
                ;
            CreateMap<nhat_ky_he_thong_loai, qtht_nhat_ky_he_thong_loaiDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.hanh_dong))

                ;
            CreateMap<qtht_nhat_ky_he_thong_loaiDTO, nhat_ky_he_thong_loai>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_nhat_ky_he_thong_loaiSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


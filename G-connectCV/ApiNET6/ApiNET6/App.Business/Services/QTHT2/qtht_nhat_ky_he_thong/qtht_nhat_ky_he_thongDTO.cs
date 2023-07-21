using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_nhat_ky_he_thongDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string bang { get; set; }
        public Guid? ban_ghi_id { get; set; }
        public Guid? nguoi_thuc_hien_id { get; set; }
        public string ten_nguoi_thuc_hien_id { get; set; }
        public string hanh_dong { get; set; }
        public string noi_dung { get; set; }
        public string duong_dan { get; set; }
        public bool? is_deleted { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_nhat_ky_he_thongProfile : Profile
    {
        public qtht_nhat_ky_he_thongProfile()
        {
            CreateMap<nhat_ky_he_thong, qtht_nhat_ky_he_thongSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.hanh_dong))
                ;
            CreateMap<nhat_ky_he_thong, qtht_nhat_ky_he_thongDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.hanh_dong))

                .ForMember(x => x.ten_nguoi_thuc_hien_id, otp => otp.MapFrom(y => y.nguoi_dung.ten))
                ;
            CreateMap<qtht_nhat_ky_he_thongDTO, nhat_ky_he_thong>()
                .ForMember(x => x.nguoi_dung, otp => otp.Ignore())                
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_nhat_ky_he_thongSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


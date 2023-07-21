using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_dieu_huongDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ma { get; set; }
        public string ten { get; set; }
        public string duong_dan { get; set; }
        public string icon { get; set; }
        public int? so_thu_tu { get; set; }
        public string stt_order { get; set; }
        public bool? is_quan_tri { get; set; }
        public string mo_ta { get; set; }
        public int cap_dieu_huong { get; set; }
        public string muc_luc { get; set; }
        public Guid? dieu_huong_cap_tren_id { get; set; }
        public bool super_admin { get; set; }
        public bool is_router { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_dieu_huongProfile : Profile
    {
        public qtht_dieu_huongProfile()
        {
            CreateMap<dieu_huong, qtht_dieu_huongSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<dieu_huong, qtht_dieu_huongDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                
                ;
            CreateMap<qtht_dieu_huongDTO, dieu_huong>()
                .ForMember(x => x.dieu_huong_cap_tren, otp => otp.Ignore())
                .ForMember(x => x.ds_dieu_huong_cap_duoi, otp => otp.Ignore())
                .ForMember(x => x.ds_nhom_nguoi_dung, otp => otp.Ignore())
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_dieu_huongSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


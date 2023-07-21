using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_LICH_HANG_NGAYDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_nguoi_thuc_hien { get; set; }
        public string ten_id_nguoi_thuc_hien { get; set; }
        public Guid? id_cong_viec { get; set; }
        public string ten_id_cong_viec { get; set; }
        public DateTime? ngay_lam_viec { get; set; }
        public DateTime? ngay_checkin { get; set; }
        public DateTime? ngay_checkout { get; set; }
        public double? so_gio { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
    }
    public class GC_LICH_HANG_NGAYProfile : Profile
    {
        public GC_LICH_HANG_NGAYProfile()
        {
            CreateMap<GC_LICH_HANG_NGAY, GC_LICH_HANG_NGAYSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.GC_CONG_VIEC_PHAN_CONG_id_cong_viec.ten_cong_viec))
                ;
            CreateMap<GC_LICH_HANG_NGAY, GC_LICH_HANG_NGAYDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.GC_CONG_VIEC_PHAN_CONG_id_cong_viec.ten_cong_viec))

                .ForMember(x => x.ten_id_nguoi_thuc_hien, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_thuc_hien.ten))
                .ForMember(x => x.ten_id_cong_viec, otp => otp.MapFrom(y => y.GC_CONG_VIEC_PHAN_CONG_id_cong_viec.ten_cong_viec))
                ;
            CreateMap<GC_LICH_HANG_NGAYDTO, GC_LICH_HANG_NGAY>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_CONG_VIEC_PHAN_CONG_id_cong_viec, otp => otp.Ignore());
        }
    }
    public class GC_LICH_HANG_NGAYSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


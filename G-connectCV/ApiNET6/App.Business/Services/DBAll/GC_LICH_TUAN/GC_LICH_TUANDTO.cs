using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_LICH_TUANDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_nguoi_thuc_hien { get; set; }
        public string ten_id_nguoi_thuc_hien { get; set; }
        public string thu2_sang { get; set; }
        public string thu2_chieu { get; set; }
        public string thu3_sang { get; set; }
        public string thu3_chieu { get; set; }
        public string thu4_sang { get; set; }
        public string thu4_chieu { get; set; }
        public string thu5_sang { get; set; }
        public string thu5_chieu { get; set; }
        public string thu6_sang { get; set; }
        public string thu6_chieu { get; set; }
        public string thu7_sang { get; set; }
        public string thu7_chieu { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
        public string so_dien_thoai { get; set; }
        public string link_bao_cao { get; set; }
    }
    public class GC_LICH_TUANProfile : Profile
    {
        public GC_LICH_TUANProfile()
        {
            CreateMap<GC_LICH_TUAN, GC_LICH_TUANSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.qtht_nguoi_dung_id_nguoi_thuc_hien.ten))
                ;
            CreateMap<GC_LICH_TUAN, GC_LICH_TUANDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.qtht_nguoi_dung_id_nguoi_thuc_hien.ten))

                .ForMember(x => x.ten_id_nguoi_thuc_hien, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_thuc_hien.ten))
                ;
            CreateMap<GC_LICH_TUANDTO, GC_LICH_TUAN>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class GC_LICH_TUANSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


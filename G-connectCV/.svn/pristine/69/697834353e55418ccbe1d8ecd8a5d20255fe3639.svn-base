using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_CONG_VIEC_PHAN_CONGDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_chuc_nang { get; set; }
        public string ten_id_chuc_nang { get; set; }
        public Guid? id_cong_viec { get; set; }
        public string ten_id_cong_viec { get; set; }
        public Guid? id_trang_thai { get; set; }
        public string ten_id_trang_thai { get; set; }
        public Guid? id_nguoi_thuc_hien { get; set; }
        public string ten_id_nguoi_thuc_hien { get; set; }
        public Guid? id_nguoi_phoi_hop { get; set; }
        public string ten_id_nguoi_phoi_hop { get; set; }
        public Guid? id_nguoi_duyet { get; set; }
        public string ten_id_nguoi_duyet { get; set; }
        public string ma_cong_viec { get; set; }
        public string ten_cong_viec { get; set; }
        public int? stt { get; set; }
        public bool? is_cong_viec_nhom { get; set; }
        public bool? is_da_code { get; set; }
        public bool? is_da_test { get; set; }
        public bool? is_da_nop_bai { get; set; }
        public bool? is_da_duyet { get; set; }
        public string noi_dung { get; set; }
        public string tham_khao { get; set; }
        public string dac_ta { get; set; }
        public string tra_loi { get; set; }
        public string log_review { get; set; }
        public string file_ket_qua { get; set; }
        public int? so_ngay_estimate { get; set; }
        public int? so_ngay_thuc_hien { get; set; }
        public DateTime? ngay_ket_thuc_du_kien { get; set; }
        public DateTime? ngay_bat_dau { get; set; }
        public DateTime? ngay_ket_thuc { get; set; }
        public int? diem_so { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_thuc_hien { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_phoi_hop { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_duyet { get; set; }

    }
    public class GC_CONG_VIEC_PHAN_CONGProfile : Profile
    {
        public GC_CONG_VIEC_PHAN_CONGProfile()
        {
            CreateMap<GC_CONG_VIEC_PHAN_CONG, GC_CONG_VIEC_PHAN_CONGSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_cong_viec))
                ;
            CreateMap<GC_CONG_VIEC_PHAN_CONG, GC_CONG_VIEC_PHAN_CONGDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_cong_viec))

                .ForMember(x => x.ten_id_chuc_nang, otp => otp.MapFrom(y => y.GC_CHUC_NANG_id_chuc_nang.ten_chuc_nang))
                .ForMember(x => x.ten_id_cong_viec, otp => otp.MapFrom(y => y.GC_CONG_VIEC_id_cong_viec.ten_cong_viec))
                .ForMember(x => x.ten_id_trang_thai, otp => otp.MapFrom(y => y.GC_DM_TRANG_THAI_id_trang_thai.ten_trang_thai))
                .ForMember(x => x.ten_id_nguoi_thuc_hien, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_thuc_hien.ten))
                .ForMember(x => x.ten_id_nguoi_phoi_hop, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_phoi_hop.ten))
                .ForMember(x => x.ten_id_nguoi_duyet, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_duyet.ten))
                ;
            CreateMap<GC_CONG_VIEC_PHAN_CONGDTO, GC_CONG_VIEC_PHAN_CONG>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_CHUC_NANG_id_chuc_nang, otp => otp.Ignore())
                .ForMember(x => x.GC_CONG_VIEC_id_cong_viec, otp => otp.Ignore())
                .ForMember(x => x.GC_DM_TRANG_THAI_id_trang_thai, otp => otp.Ignore());
        }
    }
    public class GC_CONG_VIEC_PHAN_CONGSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


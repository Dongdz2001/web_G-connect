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
    public class GC_VAN_DE_CAN_GIAI_QUYETDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
        //public Guid id { get; set; }
        public Guid? id_chuc_nang { get; set; }
        public string ten_id_chuc_nang { get; set; }
        public Guid? id_cong_viec { get; set; }
        public string ten_id_cong_viec { get; set; }
        public Guid? id_nguoi_gap { get; set; }
        public string ten_id_nguoi_gap { get; set; }
        public Guid? id_nguoi_phoi_hop { get; set; }
        public string ten_id_nguoi_phoi_hop { get; set; }
        public Guid? id_nguoi_giai_quyet { get; set; }
        public string ten_id_nguoi_giai_quyet { get; set; }
        public string ten_van_de { get; set; }
        public string noi_dung { get; set; }
        public string huong_giai_quyet { get; set; }
        public bool? da_giai_quyet { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }

        public nguoi_dung qtht_nguoi_dung_id_nguoi_gap { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_phoi_hop { get; set; }
        public nguoi_dung qtht_nguoi_dung_id_nguoi_giai_quyet { get; set; }
        public Guid? id_du_an { get; set; }
        public string ten_id_du_an { get; set; }
    }
    public class GC_VAN_DE_CAN_GIAI_QUYETProfile : Profile
    {
        public GC_VAN_DE_CAN_GIAI_QUYETProfile()
        {
            CreateMap<GC_VAN_DE_CAN_GIAI_QUYET, GC_VAN_DE_CAN_GIAI_QUYETSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_van_de))
                ;
            CreateMap<GC_VAN_DE_CAN_GIAI_QUYET, GC_VAN_DE_CAN_GIAI_QUYETDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_van_de))

                .ForMember(x => x.id_du_an, otp => otp.MapFrom(y => y.GC_CHUC_NANG_id_chuc_nang.GC_DU_AN_id_du_an.id))
                .ForMember(x => x.ten_id_du_an, otp => otp.MapFrom(y => y.GC_CHUC_NANG_id_chuc_nang.GC_DU_AN_id_du_an.ten_du_an))

                .ForMember(x => x.ten_id_chuc_nang, otp => otp.MapFrom(y => y.GC_CHUC_NANG_id_chuc_nang.ten_chuc_nang))
                .ForMember(x => x.ten_id_cong_viec, otp => otp.MapFrom(y => y.GC_CONG_VIEC_PHAN_CONG_id_cong_viec.ten_cong_viec))
                .ForMember(x => x.ten_id_nguoi_gap, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_gap.ten))
                .ForMember(x => x.ten_id_nguoi_phoi_hop, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_phoi_hop.ten))
                .ForMember(x => x.ten_id_nguoi_giai_quyet, otp => otp.MapFrom(y => y.qtht_nguoi_dung_id_nguoi_giai_quyet.ten))
                ;
            CreateMap<GC_VAN_DE_CAN_GIAI_QUYETDTO, GC_VAN_DE_CAN_GIAI_QUYET>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_CHUC_NANG_id_chuc_nang, otp => otp.Ignore())
                .ForMember(x => x.GC_CONG_VIEC_PHAN_CONG_id_cong_viec, otp => otp.Ignore());
        }
    }
    public class GC_VAN_DE_CAN_GIAI_QUYETSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


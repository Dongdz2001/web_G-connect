using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_CHUC_NANGDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_du_an { get; set; }
        public string ten_id_du_an { get; set; }
        public Guid? id_linh_vuc { get; set; }
        public string ten_id_linh_vuc { get; set; }
        public string ma_chuc_nang { get; set; }
        public string ten_chuc_nang { get; set; }
        public int? stt { get; set; }
        public bool? is_cong_bo { get; set; }
        public bool? is_da_code { get; set; }
        public bool? is_da_test { get; set; }
        public string noi_dung { get; set; }
        public string file_dinh_kem { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_CHUC_NANGProfile : Profile
    {
        public GC_CHUC_NANGProfile()
        {
            CreateMap<GC_CHUC_NANG, GC_CHUC_NANGSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_chuc_nang))
                .ForMember(x => x.id_du_an, otp => otp.MapFrom(y => y.id_du_an))
                ;
            CreateMap<GC_CHUC_NANG, GC_CHUC_NANGDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_chuc_nang))

                .ForMember(x => x.ten_id_du_an, otp => otp.MapFrom(y => y.GC_DU_AN_id_du_an.ten_du_an))
                .ForMember(x => x.ten_id_linh_vuc, otp => otp.MapFrom(y => y.GC_DM_LINH_VUC_id_linh_vuc.ten_linh_vuc))
                ;
            CreateMap<GC_CHUC_NANGDTO, GC_CHUC_NANG>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_DU_AN_id_du_an, otp => otp.Ignore())
                .ForMember(x => x.GC_DM_LINH_VUC_id_linh_vuc, otp => otp.Ignore());
        }
    }
    public class GC_CHUC_NANGSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
        public Guid id_du_an { get; set; }
    }
}


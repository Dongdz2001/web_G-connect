using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_DU_ANDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_loai_du_an { get; set; }
        public string ten_id_loai_du_an { get; set; }
        public string ten_du_an { get; set; }
        public int? stt { get; set; }
        public bool? is_da_dong { get; set; }
        public DateTime? ngay_bat_dau { get; set; }
        public DateTime? ngay_ket_thuc { get; set; }
        public string thong_tin_khach_hang { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_DU_ANProfile : Profile
    {
        public GC_DU_ANProfile()
        {
            CreateMap<GC_DU_AN, GC_DU_ANSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_du_an))
                ;
            CreateMap<GC_DU_AN, GC_DU_ANDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_du_an))

                .ForMember(x => x.ten_id_loai_du_an, otp => otp.MapFrom(y => y.GC_DM_LOAI_DU_AN_id_loai_du_an.ten_loai_du_an))
                ;
            CreateMap<GC_DU_ANDTO, GC_DU_AN>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_DM_LOAI_DU_AN_id_loai_du_an, otp => otp.Ignore());
        }
    }
    public class GC_DU_ANSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


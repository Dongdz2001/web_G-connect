using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_DM_LINH_VUCDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_linh_vuc_cha { get; set; }
        public string ten_id_linh_vuc_cha { get; set; }
        public string ten_linh_vuc { get; set; }
        public int? stt { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_DM_LINH_VUCProfile : Profile
    {
        public GC_DM_LINH_VUCProfile()
        {
            CreateMap<GC_DM_LINH_VUC, GC_DM_LINH_VUCSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_linh_vuc))
                ;
            CreateMap<GC_DM_LINH_VUC, GC_DM_LINH_VUCDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_linh_vuc))

                .ForMember(x => x.ten_id_linh_vuc_cha, otp => otp.MapFrom(y => y.GC_DM_LINH_VUC_id_linh_vuc_cha.ten_linh_vuc))
                ;
            CreateMap<GC_DM_LINH_VUCDTO, GC_DM_LINH_VUC>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_DM_LINH_VUC_id_linh_vuc_cha, otp => otp.Ignore());
        }
    }
    public class GC_DM_LINH_VUCSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


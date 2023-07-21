using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_DM_TRANG_THAIDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ten_trang_thai { get; set; }
        public int? stt { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_DM_TRANG_THAIProfile : Profile
    {
        public GC_DM_TRANG_THAIProfile()
        {
            CreateMap<GC_DM_TRANG_THAI, GC_DM_TRANG_THAISelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_trang_thai))
                ;
            CreateMap<GC_DM_TRANG_THAI, GC_DM_TRANG_THAIDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_trang_thai))

                ;
            CreateMap<GC_DM_TRANG_THAIDTO, GC_DM_TRANG_THAI>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class GC_DM_TRANG_THAISelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


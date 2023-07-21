using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_DM_LOAI_CHECK_LISTDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ten_loai_check_list { get; set; }
        public int? stt { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_DM_LOAI_CHECK_LISTProfile : Profile
    {
        public GC_DM_LOAI_CHECK_LISTProfile()
        {
            CreateMap<GC_DM_LOAI_CHECK_LIST, GC_DM_LOAI_CHECK_LISTSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_loai_check_list))
                ;
            CreateMap<GC_DM_LOAI_CHECK_LIST, GC_DM_LOAI_CHECK_LISTDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_loai_check_list))

                ;
            CreateMap<GC_DM_LOAI_CHECK_LISTDTO, GC_DM_LOAI_CHECK_LIST>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class GC_DM_LOAI_CHECK_LISTSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


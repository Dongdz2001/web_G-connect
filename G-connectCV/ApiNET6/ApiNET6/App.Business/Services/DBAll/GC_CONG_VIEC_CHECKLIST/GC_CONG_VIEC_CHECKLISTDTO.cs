using App.Business.Base;
using App.Data;
using App.Data.Models.DBAll;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.DBAll
{
    public class GC_CONG_VIEC_CHECKLISTDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public Guid? id_chuc_nang { get; set; }
        public string ten_id_chuc_nang { get; set; }
        public Guid? id_cong_viec { get; set; }
        public string ten_id_cong_viec { get; set; }
        public Guid? id_loai_checklist { get; set; }
        public string ten_id_loai_checklist { get; set; }
        public string ma_cong_viec { get; set; }
        public string ten_cong_viec { get; set; }
        public int? stt { get; set; }
        public string ket_qua_mong_muon { get; set; }
        public string ghi_chu_khac { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class GC_CONG_VIEC_CHECKLISTProfile : Profile
    {
        public GC_CONG_VIEC_CHECKLISTProfile()
        {
            CreateMap<GC_CONG_VIEC_CHECKLIST, GC_CONG_VIEC_CHECKLISTSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_cong_viec))
                ;
            CreateMap<GC_CONG_VIEC_CHECKLIST, GC_CONG_VIEC_CHECKLISTDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten_cong_viec))

                .ForMember(x => x.ten_id_chuc_nang, otp => otp.MapFrom(y => y.GC_CHUC_NANG_id_chuc_nang.ten_chuc_nang))
                .ForMember(x => x.ten_id_cong_viec, otp => otp.MapFrom(y => y.GC_CONG_VIEC_id_cong_viec.ten_cong_viec))
                .ForMember(x => x.ten_id_loai_checklist, otp => otp.MapFrom(y => y.GC_DM_LOAI_CHECK_LIST_id_loai_checklist.ten_loai_check_list))
                ;
            CreateMap<GC_CONG_VIEC_CHECKLISTDTO, GC_CONG_VIEC_CHECKLIST>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.GC_CHUC_NANG_id_chuc_nang, otp => otp.Ignore())
                .ForMember(x => x.GC_CONG_VIEC_id_cong_viec, otp => otp.Ignore())
                .ForMember(x => x.GC_DM_LOAI_CHECK_LIST_id_loai_checklist, otp => otp.Ignore());
        }
    }
    public class GC_CONG_VIEC_CHECKLISTSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


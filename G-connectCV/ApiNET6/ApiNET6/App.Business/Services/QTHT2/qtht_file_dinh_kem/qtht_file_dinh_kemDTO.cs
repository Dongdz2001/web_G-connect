using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT2
{
    public class qtht_file_dinh_kemDTO : BaseDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }

        //public Guid id { get; set; }
        public string ten { get; set; }
        public string duong_dan { get; set; }
        public string type { get; set; }
        public byte[]? noi_dung_tep { get; set; }
        public byte[]? noi_dung_tep_pdf { get; set; }
        public byte[]? file_finish { get; set; }
        //public Guid? nguoi_tao_id { get; set; }
        //public DateTime? ngay_tao { get; set; }
        //public Guid? nguoi_chinh_sua_id { get; set; }
        //public DateTime? ngay_chinh_sua { get; set; }
    }
    public class qtht_file_dinh_kemProfile : Profile
    {
        public qtht_file_dinh_kemProfile()
        {
            CreateMap<file_dinh_kem, qtht_file_dinh_kemSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
                ;
            CreateMap<file_dinh_kem, qtht_file_dinh_kemDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))

                ;
            CreateMap<qtht_file_dinh_kemDTO, file_dinh_kem>()
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class qtht_file_dinh_kemSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}


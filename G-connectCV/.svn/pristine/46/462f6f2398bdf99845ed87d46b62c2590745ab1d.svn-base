using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public class NhatKyHeThongDTO : BaseDTO
    {
        public string bang { get; set; }
        public Guid? ban_ghi_id { get; set; }
        public Guid? nguoi_thuc_hien_id { get; set; }
        public string hanh_dong { get; set; }
        public string noi_dung { get; set; }
        public string duong_dan { get; set; }
        public bool? is_deleted { get; set; }

        public NguoiDungDTO nguoi_gui_thuc_hien { get; set; }
    }
    public class NhatKyHeThongProfile : Profile
    {
        public NhatKyHeThongProfile()
        {
            CreateMap<nhat_ky_he_thong, NhatKyHeThongDTO>()
            .ForMember(x => x.nguoi_gui_thuc_hien, otp => otp.MapFrom(x => new NguoiDungDTO { 
                ten = x.nguoi_dung.ten,
                id = x.nguoi_dung.id
            }));

            CreateMap<NhatKyHeThongDTO, nhat_ky_he_thong>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.nguoi_dung, otp => otp.Ignore());
            ;
        }
    }

}

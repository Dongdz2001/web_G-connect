using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Business.Services.QTHT
{
    public class NguoiDungDTO : BaseDTO
    {
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public string salt_code { get; set; }
        public string ten { get; set; }
        public int trang_thai { get; set; }
        public bool super_admin { get; set; }
        public bool? is_dau_moi { get; set; }
        public string email { get; set; }
        public string so_dien_thoai { get; set; }
        public string anh_dai_dien_url { get; set; }
        public string str_ma_nhom_nguoi_dung { get; set; }
        public Guid? chuc_vu_id { get; set; }
        public Guid? file_dinh_kem_id { get; set; }
        public ChucVuSelectDTO chuc_vu { get; set; }
        public List<nhom_nguoi_dung> ds_nhomnguoidung { get; set; }

        public FileDinhKemDTO file { get; set; }
    }
    public class NguoiDungProfile : Profile
    {
        public NguoiDungProfile()
        {
            CreateMap<chuc_vu, ChucVuSelectDTO>()
                .ForMember(d => d.value, opt => opt.MapFrom(x => x.id))
                .ForMember(d => d.label, opt => opt.MapFrom(x => x.ten));
            CreateMap<nguoi_dung, NguoiDungDTO>()
                .ForMember(x => x.str_ma_nhom_nguoi_dung, otp => otp.MapFrom(z => z.ds_nhom_nguoi_dung != null ? string.Join(",", z.ds_nhom_nguoi_dung.Select(x => x.nhom_nguoi_dung.ma).ToList()) : ""))
                //.ForMember(d => d.ds_nhomnguoidung, opt => opt.MapFrom(x => x.ds_nhom_nguoi_dung.Select(y => y.nhom_nguoi_dung)))
                .ForMember(d => d.ds_nhomnguoidung, opt => opt.Ignore())
                    .AfterMap((s, d) =>
                    {
                        if (s.ds_nhom_nguoi_dung.Any())
                        {
                            d.ds_nhomnguoidung = s.ds_nhom_nguoi_dung.Select(x => new nhom_nguoi_dung
                            {
                                id = x.nhom_nguoi_dung != null ? x.nhom_nguoi_dung.id : new Guid(),
                                ma = x.nhom_nguoi_dung?.ma,
                                ten = x.nhom_nguoi_dung?.ten,
                                mota = x.nhom_nguoi_dung?.mota
                            }).ToList();
                        }
                        else
                        {
                            d.ds_nhomnguoidung = new List<nhom_nguoi_dung>();
                        }
                    })
                .ForMember(x => x.mat_khau, otp => otp.Ignore())
                .ForMember(x => x.salt_code, otp => otp.Ignore())
                 .ForMember(d => d.file, opt => opt.MapFrom(x => x.file_dinh_kem));
            CreateMap<nguoi_dung, NguoiDungSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten));
            CreateMap<nguoi_dung, NguoiDungEmailSelectDTO>()
                .ForMember(x => x.value, otp => otp.MapFrom(z => z.email))
                .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten));
            CreateMap<NguoiDungDTO, nguoi_dung>()
                .IncludeBase<BaseDTO, BaseModel>()
                .ForMember(x => x.mat_khau, otp => otp.Ignore())
                .ForMember(x => x.salt_code, otp => otp.Ignore())
                .ForMember(x => x.chuc_vu, otp => otp.Ignore())
                .ForMember(x => x.ds_nhom_nguoi_dung, otp => otp.Ignore())
                .ForMember(x => x.file_dinh_kem, otp => otp.Ignore())
                ;
        }
    }

    public class UpdateNhomNDFromND
    {
        public Guid nguoi_dung_id { get; set; }
        public List<nhom_nguoi_dung> lts_nhom_id { get; set; }
    }

    public class PermissionUserDTO
    {
        public string ma_quyen { get; set; }
    }

    public class NguoiDungSelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
    public class NguoiDungEmailSelectDTO
    {
        public string value { get; set; }
        public string label { get; set; }
    }
}

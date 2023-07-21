using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Business.Services.QTHT
{
    public class NhomNguoiDungDTO : BaseDTO
    {
        public string ma { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public Guid? value { get; set; }
        public string label { get; set; }
        public List<NguoiDung_SelectDTO> ds_nguoidung_1 { get; set; }
        public List<nguoi_dung> ds_nguoidung { get; set; }
        public List<DieuHuongDTO> ds_dieuhuong { get; set; }
    }
    public class NhomNguoiDungProfile : Profile
    {
        public NhomNguoiDungProfile()
        {
            CreateMap<nhom_nguoi_dung, NhomNguoiDungDTO>()
            .ForMember(d => d.ds_nguoidung_1, opt => opt.MapFrom(z => z.ds_nguoi_dung.Any()? z.ds_nguoi_dung.Select(
               y => new  NguoiDung_SelectDTO {
                   value = y.nguoi_dung != null ? y.nguoi_dung.id : new Guid(),
                   label = y.nguoi_dung != null ? y.nguoi_dung.ten : null
            }).ToList() : null ))
            .ForMember(x => x.ds_nguoidung,otp => otp.Ignore())
             .ForMember(x => x.value, otp => otp.MapFrom(z => z.id))
             .ForMember(x => x.label, otp => otp.MapFrom(z => z.ten))
            .AfterMap((s, d) =>
            {
                if (s.ds_nguoi_dung.Any())
                {
                    d.ds_nguoidung = s.ds_nguoi_dung.Select(x => new nguoi_dung
                    {
                        id = x.nguoi_dung != null ? x.nguoi_dung.id : new Guid(),
                        ten = x.nguoi_dung?.ten,
                        tai_khoan = x.nguoi_dung?.tai_khoan,
                    }).ToList();
                }
                else
                {
                    d.ds_nguoidung = new List<nguoi_dung>();
                }
            })
            .ForMember(d => d.ds_dieuhuong, opt => opt.Ignore())
            .AfterMap((s, d) =>
            {
                if (s.ds_dieu_huong.Any())
                {
                    d.ds_dieuhuong = s.ds_dieu_huong.Select(x => new DieuHuongDTO
                    {
                        id = x.dieu_huong != null ? x.dieu_huong.id : new Guid(),
                        ma = x.dieu_huong?.ma,
                        ten = x.dieu_huong?.ten,
                        so_thu_tu = x.dieu_huong.so_thu_tu,
                        is_quan_tri = x.dieu_huong.is_quan_tri,
                        cap_dieu_huong = x.dieu_huong.cap_dieu_huong,
                        muc_luc = x.dieu_huong.muc_luc,
                        dieu_huong_cap_tren_id = x.dieu_huong.dieu_huong_cap_tren_id
                    }).ToList();
                }
                else
                {
                    d.ds_dieuhuong = new List<DieuHuongDTO>();
                }
            });
            CreateMap<NhomNguoiDungDTO, nhom_nguoi_dung>()
            .IncludeBase<BaseDTO, BaseModel>()
            .ForMember(x => x.ds_nguoi_dung, otp => otp.Ignore())
            .ForMember(x => x.ds_dieu_huong, otp => otp.Ignore());
        }
    }
    public class UpdateNguoiDungFromNhomND
    {
        public Guid nhom_id { get; set; }
        public List<nguoi_dung> lts_nguoi_dung_id { get; set; }
    }
    public class NguoiDung_SelectDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
    }
}

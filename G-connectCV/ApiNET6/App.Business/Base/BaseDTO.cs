using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using TemplateEngine.Docx;

namespace App.Business.Base
{
    public class BaseDTOInt
    {
        public int id { get; set; }
    }
    public class BaseDTO
    {
        public Guid id { get; set; }
        public Guid? nguoi_tao_id { get; set; }
        public NguoiTaoDTO nguoi_tao { get; set; }
        public DateTime? ngay_tao { get; set; }
        public Guid? nguoi_chinh_sua_id { get; set; }
        public NguoiChinhSuaDTO nguoi_chinh_sua { get; set; }
        public DateTime? ngay_chinh_sua { get; set; }
    }
    public class NguoiTaoDTO
    {
        public Guid id { get; set; }
        public string tai_khoan { get; set; }
        public string ten { get; set; }
    }
    public class NguoiChinhSuaDTO
    {
        public Guid id { get; set; }
        public string tai_khoan { get; set; }
        public string ten { get; set; }
    }
    public class SelectDTO
    {
        public Guid id { get; set; }
        public string ten { get; set; }
    }
    public class SelectSimpleDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
        public int? loai { get; set; }
    }
    public class SelectNhiemVuDTO
    {
         public List<SelectSimpleNhiemVuDTO>  list_ds_nv_soan_thao { get; set; }
         public List<SelectSimpleNhiemVuDTO> list_ds_nv_cap_nhap  { get; set; }

    }
    public class SelectSimpleNhiemVuDTO
    {
        public Guid value { get; set; }
        public string label { get; set; }
        public string ma_nhiem_vu    { get; set; }
        public int is_duan_nhiemvu_hoso { get; set; }

    }
    public class SelectSimpleTCCTDTO
    {
        public Guid? value { get; set; }
        public string label { get; set; }
    }
    public class SelectSimpleIntDTO
    {
        public int? value { get; set; }
        public string label { get; set; }
    }
    public class SelectSimpleStringDTO
    {
        public string value { get; set; }
        public string label { get; set; }
    }
    public class SelectSimpleIntOrderDTO
    {
        public int? value { get; set; }
        public string label { get; set; }
        public int? stt_order { get; set; }
    }
    public class FileDTO
    {
        public string path_out { get; set; }
        public Content valuesToFill { get; set; }
        public string TenFile { get; set; }
    }
    public enum TrangThaiNV
    {
        KYHOPDONG = 1,
        DUNGXD = 2,
        NGHIEMTHU = 3,
        DUNGKT = 4
    }
    public enum TrangThaiTC
    {
        TAOBK = 1,
        GUIBK = 2,
        KHOABK = 3,
        KETTHUC = 4,
    }
    public class BaseProfileInt : Profile
    {
        public BaseProfileInt()
        {
            CreateMap<BaseDTOInt, BaseModelInt>();
        }
    }
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<nguoi_dung, NguoiChinhSuaDTO>();
            CreateMap<nguoi_dung, NguoiTaoDTO>();
            CreateMap<BaseDTO, BaseModel>()
            .ForMember(d => d.nguoi_tao, opt => opt.Ignore())
            .ForMember(d => d.nguoi_tao_id, opt => opt.Ignore())
            .ForMember(d => d.ngay_tao, opt => opt.Ignore())
            .ForMember(d => d.nguoi_chinh_sua, opt => opt.Ignore());
        }
    }
}

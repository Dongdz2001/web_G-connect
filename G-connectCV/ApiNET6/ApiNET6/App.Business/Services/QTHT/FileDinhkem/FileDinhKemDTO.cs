using App.Business.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace App.Business.Services.QTHT
{
    public class FileDinhKemDTO : BaseDTO
    {
        public string tenFile { get; set; }
        public string linkFile { get; set; }
        public string type { get; set; }
        public byte[] noi_dung_tep { get; set; }
        public byte[] file_finish { get; set; }
        public byte[] noi_dung_tep_pdf { get; set; }
    }
    public class FileDinhKemViewXNKLCVDTO : BaseDTO
    {
        public string tenFile { get; set; }
        public string linkFile { get; set; }
        public string type { get; set; }
        public int loai { get; set; }
    }
    public class FileDinhKemViewDTO : BaseDTO
    {
        public string tenFile { get; set; }
        public string linkFile { get; set; }
        public string type { get; set; }
        public string loai { get; set; }
    }
    public class FileTacNghiepDTO
    {
        public FileDinhKemViewDTO file_dinh_kem { get; set; }
        public string ten_bieu_mau { get; set; }
    }

    public class FileDinhKemProfile : Profile
    {
        public FileDinhKemProfile()
        {
            CreateMap<file_dinh_kem, FileDinhKemViewXNKLCVDTO>()
               .ForMember(d => d.tenFile, opt => opt.MapFrom(x => x.ten))
               .ForMember(d => d.loai, opt => opt.Ignore())
                .ForMember(d => d.linkFile, opt => opt.MapFrom(x => x.duong_dan));
            CreateMap<file_dinh_kem,FileDinhKemViewDTO>()
                .ForMember(d => d.tenFile, opt => opt.MapFrom(x => x.ten))
                .ForMember(d => d.loai, opt => opt.Ignore())
                 .ForMember(d => d.linkFile, opt => opt.MapFrom(x => x.duong_dan));
            CreateMap<file_dinh_kem, FileDinhKemDTO>()
                 .ForMember(d => d.tenFile, opt => opt.MapFrom(x => x.ten))
                 .ForMember(d => d.type, opt => opt.MapFrom(x => x.type))
                 .ForMember(d => d.linkFile, opt => opt.MapFrom(x => x.duong_dan));
            CreateMap<FileDinhKemDTO, file_dinh_kem>()
                .ForMember(d => d.ten, opt => opt.MapFrom(x => x.tenFile))
                 .ForMember(d => d.duong_dan, opt => opt.MapFrom(x => x.linkFile))
                .IncludeBase<BaseDTO, BaseModel>();
        }
    }
    public class FileUpload
    {
        public List<IFormFile> files { get; set; }
        public string urlPath { get; set; }
    }

    public class FileUploadImportDuToan
    {
        public List<IFormFile> files { get; set; }
        public string urlPath { get; set; }
        public Guid chuong_trinh_id { get; set; }
        public Guid nhiem_vu_id { get; set; }
    }

    public class FileUploadImportDuLieuDuToan
    {
        public List<IFormFile> files { get; set; }
        public string urlPath { get; set; }
        public Guid chuong_trinh_id { get; set; }
        public Guid nhiem_vu_id { get; set; }
        public List<Guid> ds_mau_dt_ids { get; set; }
        public Guid? buoc_id { get; set; }
        public int? trang_thai { get; set; }
        public Guid loai_hinh_nhiem_vu_id { get; set; }
        public string ma_loai_chi_phi { get; set; }
        public int loai { get; set; }
    }

    public class outPutUploadFile
    {
        public string linkFile { get; set; }
        public string tenFile { get; set; }
        public string type { get; set; }
        public Guid id { get; set; }
    }

    public class inPutViewFile
    {
        public Guid file_dinh_kem_id { get; set; }
        public string du_lieu_mau { get; set; }
    }
}

using App.Business.Base;
using App.Business.Utils;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.QTHT
{
    public class FileDinhKemService : GenericService<file_dinh_kem>, IFileDinhKemService
    {
        public FileDinhKemService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<FileDinhKemProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();

        }

        protected override IQueryable<file_dinh_kem> QueryBuilder(IQueryable<file_dinh_kem> query, dynamic filter, string search)
        {
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {

        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref file_dinh_kem entity)
        {
            if (typeof(TDto) != typeof(FileDinhKemDTO))
            {
                return;
            }
            FileDinhKemDTO fileDinhKemDTO = (FileDinhKemDTO)(object)dto;
            if (isNew)
            {

            }
        }

        public FileDinhKemDTO convertTodoc(Guid file_dinh_kem_id)
        {
            FileDinhKemDTO fileDinhKemDTO = new FileDinhKemDTO();
            var info_file = _repo.Find(file_dinh_kem_id);
            if(info_file != null)
            {
                var name_file = info_file.ten;
                if (info_file.ten.Contains("."))
                {
                    name_file = info_file.ten.Substring(0,info_file.ten.IndexOf("."));
                }
                byte[] bytes = DocxHanlder.PdfToDocx(info_file.noi_dung_tep_pdf);
                fileDinhKemDTO.type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                fileDinhKemDTO.tenFile = name_file + ".docx";
                fileDinhKemDTO.noi_dung_tep = bytes;
                return fileDinhKemDTO;
            }
            return null;
        }
    }
}

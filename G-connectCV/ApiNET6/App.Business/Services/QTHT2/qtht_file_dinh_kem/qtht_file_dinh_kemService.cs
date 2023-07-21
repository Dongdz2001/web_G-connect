using AutoMapper;
using System;
using System.Net;
using System.Linq;
using App.Business.Base;
using App.Business.Utils;
using App.Business.Services.QTHT;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using App.Data.Models.QTHT2;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace App.Business.Services.QTHT2
{
    public class qtht_file_dinh_kemService : GenericService<file_dinh_kem>, qtht_file_dinh_kemIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_file_dinh_kemService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_file_dinh_kemProfile>();
                //cfg.CreateMap<IDataRecord, qtht_file_dinh_kemDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<file_dinh_kem> QueryBuilder(IQueryable<file_dinh_kem> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string ten = filter.ten + "";
                if (!string.IsNullOrEmpty(ten))
                {
                    ten = ten.ToLower().Trim();
                    query = query.Where(x => x.ten.ToLower().Contains(ten));
                }
                string duong_dan = filter.duong_dan + "";
                if (!string.IsNullOrEmpty(duong_dan))
                {
                    duong_dan = duong_dan.ToLower().Trim();
                    query = query.Where(x => x.duong_dan.ToLower().Contains(duong_dan));
                }
                string type = filter.type + "";
                if (!string.IsNullOrEmpty(type))
                {
                    type = type.ToLower().Trim();
                    query = query.Where(x => x.type.ToLower().Contains(type));
                }
                string noi_dung_tep = filter.noi_dung_tep + "";
                if (!string.IsNullOrEmpty(noi_dung_tep))
                {
                    noi_dung_tep = noi_dung_tep.ToLower().Trim();
                    //query = query.Where(x => x.noi_dung_tep.ToLower().Contains(noi_dung_tep));
                }
                string noi_dung_tep_pdf = filter.noi_dung_tep_pdf + "";
                if (!string.IsNullOrEmpty(noi_dung_tep_pdf))
                {
                    noi_dung_tep_pdf = noi_dung_tep_pdf.ToLower().Trim();
                    //query = query.Where(x => x.noi_dung_tep_pdf.ToLower().Contains(noi_dung_tep_pdf));
                }
                string file_finish = filter.file_finish + "";
                if (!string.IsNullOrEmpty(file_finish))
                {
                    file_finish = file_finish.ToLower().Trim();
                    ///query = query.Where(x => x.file_finish.ToLower().Contains(file_finish));
                }
                string nguoi_tao_id = filter.nguoi_tao_id + "";
                if (!string.IsNullOrEmpty(nguoi_tao_id))
                {
                    var guid_nguoi_tao_id = Guid.Parse(nguoi_tao_id);
                    query = query.Where(x => x.nguoi_tao_id == guid_nguoi_tao_id);
                }
                string ngay_tao = filter.ngay_tao + "";
                if (!string.IsNullOrEmpty(ngay_tao))
                {
                    var date_ngay_tao = DateTime.Parse(ngay_tao);
                    query = query.Where(x => x.ngay_tao == date_ngay_tao);
                }
                string bd_ngay_tao = filter.bd_ngay_tao + "";
                if (!string.IsNullOrEmpty(bd_ngay_tao))
                {
                    var bd_date_ngay_tao = DateTime.Parse(bd_ngay_tao);
                    query = query.Where(x => x.ngay_tao >= bd_date_ngay_tao);
                }
                string kt_ngay_tao = filter.kt_ngay_tao + "";
                if (!string.IsNullOrEmpty(kt_ngay_tao))
                {
                    var kt_date_ngay_tao = DateTime.Parse(kt_ngay_tao);
                    query = query.Where(x => x.ngay_tao <= kt_date_ngay_tao);
                }
                string nguoi_chinh_sua_id = filter.nguoi_chinh_sua_id + "";
                if (!string.IsNullOrEmpty(nguoi_chinh_sua_id))
                {
                    var guid_nguoi_chinh_sua_id = Guid.Parse(nguoi_chinh_sua_id);
                    query = query.Where(x => x.nguoi_chinh_sua_id == guid_nguoi_chinh_sua_id);
                }
                string ngay_chinh_sua = filter.ngay_chinh_sua + "";
                if (!string.IsNullOrEmpty(ngay_chinh_sua))
                {
                    var date_ngay_chinh_sua = DateTime.Parse(ngay_chinh_sua);
                    query = query.Where(x => x.ngay_chinh_sua == date_ngay_chinh_sua);
                }
                string bd_ngay_chinh_sua = filter.bd_ngay_chinh_sua + "";
                if (!string.IsNullOrEmpty(bd_ngay_chinh_sua))
                {
                    var bd_date_ngay_chinh_sua = DateTime.Parse(bd_ngay_chinh_sua);
                    query = query.Where(x => x.ngay_chinh_sua >= bd_date_ngay_chinh_sua);
                }
                string kt_ngay_chinh_sua = filter.kt_ngay_chinh_sua + "";
                if (!string.IsNullOrEmpty(kt_ngay_chinh_sua))
                {
                    var kt_date_ngay_chinh_sua = DateTime.Parse(kt_ngay_chinh_sua);
                    query = query.Where(x => x.ngay_chinh_sua <= kt_date_ngay_chinh_sua);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.ten.ToLower().Contains(search) 
                    || x.duong_dan.ToLower().Contains(search) 
                    || x.type.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_file_dinh_kemDTO))
            {
                qtht_file_dinh_kemDTO qtht_file_dinh_kemDTO = (qtht_file_dinh_kemDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_file_dinh_kemDTO.ma.ToLower() && x.id != qtht_file_dinh_kemDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref file_dinh_kem entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_file_dinh_kemDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref file_dinh_kem entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_file_dinh_kemDTO))
            {

            }
        }

        //add more

    }
}


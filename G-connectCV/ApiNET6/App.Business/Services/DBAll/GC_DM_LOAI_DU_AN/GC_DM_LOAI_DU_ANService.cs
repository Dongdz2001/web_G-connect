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
using App.Data.Models.DBAll;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace App.Business.Services.DBAll
{
    public class GC_DM_LOAI_DU_ANService : GenericService<GC_DM_LOAI_DU_AN>, GC_DM_LOAI_DU_ANIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_DM_LOAI_DU_ANService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_DM_LOAI_DU_ANProfile>();
                //cfg.CreateMap<IDataRecord, GC_DM_LOAI_DU_ANDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_DM_LOAI_DU_AN> QueryBuilder(IQueryable<GC_DM_LOAI_DU_AN> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string ten_loai_du_an = filter.ten_loai_du_an + "";
                if (!string.IsNullOrEmpty(ten_loai_du_an))
                {
                    ten_loai_du_an = ten_loai_du_an.ToLower().Trim();
                    query = query.Where(x => x.ten_loai_du_an.ToLower().Contains(ten_loai_du_an));
                }
                string stt = filter.stt + "";
                if (!string.IsNullOrEmpty(stt))
                {
                    var int_stt = int.Parse(stt);
                    query = query.Where(x => x.stt == int_stt);
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

                    || x.ten_loai_du_an.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_DM_LOAI_DU_ANDTO))
            {
                GC_DM_LOAI_DU_ANDTO GC_DM_LOAI_DU_ANDTO = (GC_DM_LOAI_DU_ANDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_DM_LOAI_DU_ANDTO.ma.ToLower() && x.id != GC_DM_LOAI_DU_ANDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_DM_LOAI_DU_AN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_DM_LOAI_DU_ANDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_DM_LOAI_DU_AN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_DM_LOAI_DU_ANDTO))
            {

            }
        }

        //add more

    }
}


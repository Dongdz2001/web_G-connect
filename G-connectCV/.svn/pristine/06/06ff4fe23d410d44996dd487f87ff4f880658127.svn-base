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
    public class GC_DU_ANService : GenericService<GC_DU_AN>, GC_DU_ANIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_DU_ANService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_DU_ANProfile>();
                //cfg.CreateMap<IDataRecord, GC_DU_ANDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_DU_AN> QueryBuilder(IQueryable<GC_DU_AN> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string id_loai_du_an = filter.id_loai_du_an + "";
                if (!string.IsNullOrEmpty(id_loai_du_an))
                {
                    var guid_id_loai_du_an = Guid.Parse(id_loai_du_an);
                    query = query.Where(x => x.id_loai_du_an == guid_id_loai_du_an);
                }
                string ten_du_an = filter.ten_du_an + "";
                if (!string.IsNullOrEmpty(ten_du_an))
                {
                    ten_du_an = ten_du_an.ToLower().Trim();
                    query = query.Where(x => x.ten_du_an.ToLower().Contains(ten_du_an));
                }
                string stt = filter.stt + "";
                if (!string.IsNullOrEmpty(stt))
                {
                    var int_stt = int.Parse(stt);
                    query = query.Where(x => x.stt == int_stt);
                }
                string is_da_dong = filter.is_da_dong + "";
                if (!string.IsNullOrEmpty(is_da_dong))
                {
                    var bool_is_da_dong = bool.Parse(is_da_dong);
                    query = query.Where(x => x.is_da_dong == bool_is_da_dong);
                }
                string ngay_bat_dau = filter.ngay_bat_dau + "";
                if (!string.IsNullOrEmpty(ngay_bat_dau))
                {
                    var date_ngay_bat_dau = DateTime.Parse(ngay_bat_dau);
                    query = query.Where(x => x.ngay_bat_dau == date_ngay_bat_dau);
                }
                string bd_ngay_bat_dau = filter.bd_ngay_bat_dau + "";
                if (!string.IsNullOrEmpty(bd_ngay_bat_dau))
                {
                    var bd_date_ngay_bat_dau = DateTime.Parse(bd_ngay_bat_dau);
                    query = query.Where(x => x.ngay_bat_dau >= bd_date_ngay_bat_dau);
                }
                string kt_ngay_bat_dau = filter.kt_ngay_bat_dau + "";
                if (!string.IsNullOrEmpty(kt_ngay_bat_dau))
                {
                    var kt_date_ngay_bat_dau = DateTime.Parse(kt_ngay_bat_dau);
                    query = query.Where(x => x.ngay_bat_dau <= kt_date_ngay_bat_dau);
                }
                string ngay_ket_thuc = filter.ngay_ket_thuc + "";
                if (!string.IsNullOrEmpty(ngay_ket_thuc))
                {
                    var date_ngay_ket_thuc = DateTime.Parse(ngay_ket_thuc);
                    query = query.Where(x => x.ngay_ket_thuc == date_ngay_ket_thuc);
                }
                string bd_ngay_ket_thuc = filter.bd_ngay_ket_thuc + "";
                if (!string.IsNullOrEmpty(bd_ngay_ket_thuc))
                {
                    var bd_date_ngay_ket_thuc = DateTime.Parse(bd_ngay_ket_thuc);
                    query = query.Where(x => x.ngay_ket_thuc >= bd_date_ngay_ket_thuc);
                }
                string kt_ngay_ket_thuc = filter.kt_ngay_ket_thuc + "";
                if (!string.IsNullOrEmpty(kt_ngay_ket_thuc))
                {
                    var kt_date_ngay_ket_thuc = DateTime.Parse(kt_ngay_ket_thuc);
                    query = query.Where(x => x.ngay_ket_thuc <= kt_date_ngay_ket_thuc);
                }
                string thong_tin_khach_hang = filter.thong_tin_khach_hang + "";
                if (!string.IsNullOrEmpty(thong_tin_khach_hang))
                {
                    thong_tin_khach_hang = thong_tin_khach_hang.ToLower().Trim();
                    query = query.Where(x => x.thong_tin_khach_hang.ToLower().Contains(thong_tin_khach_hang));
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

                    || x.ten_du_an.ToLower().Contains(search) 
                    || x.thong_tin_khach_hang.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_DU_ANDTO))
            {
                GC_DU_ANDTO GC_DU_ANDTO = (GC_DU_ANDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_DU_ANDTO.ma.ToLower() && x.id != GC_DU_ANDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_DU_AN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_DU_ANDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_DU_AN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_DU_ANDTO))
            {

            }
        }

        //add more

    }
}


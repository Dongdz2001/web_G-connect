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
    public class GC_LICH_HANG_NGAYService : GenericService<GC_LICH_HANG_NGAY>, GC_LICH_HANG_NGAYIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_LICH_HANG_NGAYService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_LICH_HANG_NGAYProfile>();
                //cfg.CreateMap<IDataRecord, GC_LICH_HANG_NGAYDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_LICH_HANG_NGAY> QueryBuilder(IQueryable<GC_LICH_HANG_NGAY> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string id_nguoi_thuc_hien = filter.id_nguoi_thuc_hien + "";
                if (!string.IsNullOrEmpty(id_nguoi_thuc_hien))
                {
                    var guid_id_nguoi_thuc_hien = Guid.Parse(id_nguoi_thuc_hien);
                    query = query.Where(x => x.id_nguoi_thuc_hien == guid_id_nguoi_thuc_hien);
                }
                string id_cong_viec = filter.id_cong_viec + "";
                if (!string.IsNullOrEmpty(id_cong_viec))
                {
                    var guid_id_cong_viec = Guid.Parse(id_cong_viec);
                    query = query.Where(x => x.id_cong_viec == guid_id_cong_viec);
                }
                string ngay_lam_viec = filter.ngay_lam_viec + "";
                if (!string.IsNullOrEmpty(ngay_lam_viec))
                {
                    var date_ngay_lam_viec = DateTime.Parse(ngay_lam_viec);
                    query = query.Where(x => x.ngay_lam_viec == date_ngay_lam_viec);
                }
                string bd_ngay_lam_viec = filter.bd_ngay_lam_viec + "";
                if (!string.IsNullOrEmpty(bd_ngay_lam_viec))
                {
                    var bd_date_ngay_lam_viec = DateTime.Parse(bd_ngay_lam_viec);
                    query = query.Where(x => x.ngay_lam_viec >= bd_date_ngay_lam_viec);
                }
                string kt_ngay_lam_viec = filter.kt_ngay_lam_viec + "";
                if (!string.IsNullOrEmpty(kt_ngay_lam_viec))
                {
                    var kt_date_ngay_lam_viec = DateTime.Parse(kt_ngay_lam_viec);
                    query = query.Where(x => x.ngay_lam_viec <= kt_date_ngay_lam_viec);
                }
                string ngay_checkin = filter.ngay_checkin + "";
                if (!string.IsNullOrEmpty(ngay_checkin))
                {
                    var date_ngay_checkin = DateTime.Parse(ngay_checkin);
                    query = query.Where(x => x.ngay_checkin == date_ngay_checkin);
                }
                string bd_ngay_checkin = filter.bd_ngay_checkin + "";
                if (!string.IsNullOrEmpty(bd_ngay_checkin))
                {
                    var bd_date_ngay_checkin = DateTime.Parse(bd_ngay_checkin);
                    query = query.Where(x => x.ngay_checkin >= bd_date_ngay_checkin);
                }
                string kt_ngay_checkin = filter.kt_ngay_checkin + "";
                if (!string.IsNullOrEmpty(kt_ngay_checkin))
                {
                    var kt_date_ngay_checkin = DateTime.Parse(kt_ngay_checkin);
                    query = query.Where(x => x.ngay_checkin <= kt_date_ngay_checkin);
                }
                string ngay_checkout = filter.ngay_checkout + "";
                if (!string.IsNullOrEmpty(ngay_checkout))
                {
                    var date_ngay_checkout = DateTime.Parse(ngay_checkout);
                    query = query.Where(x => x.ngay_checkout == date_ngay_checkout);
                }
                string bd_ngay_checkout = filter.bd_ngay_checkout + "";
                if (!string.IsNullOrEmpty(bd_ngay_checkout))
                {
                    var bd_date_ngay_checkout = DateTime.Parse(bd_ngay_checkout);
                    query = query.Where(x => x.ngay_checkout >= bd_date_ngay_checkout);
                }
                string kt_ngay_checkout = filter.kt_ngay_checkout + "";
                if (!string.IsNullOrEmpty(kt_ngay_checkout))
                {
                    var kt_date_ngay_checkout = DateTime.Parse(kt_ngay_checkout);
                    query = query.Where(x => x.ngay_checkout <= kt_date_ngay_checkout);
                }
                string so_gio = filter.so_gio + "";
                if (!string.IsNullOrEmpty(so_gio))
                {
                    so_gio = so_gio.ToLower().Trim();
                    //query = query.Where(x => x.so_gio.ToLower().Contains(so_gio));
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

                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_LICH_HANG_NGAYDTO))
            {
                GC_LICH_HANG_NGAYDTO GC_LICH_HANG_NGAYDTO = (GC_LICH_HANG_NGAYDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_LICH_HANG_NGAYDTO.ma.ToLower() && x.id != GC_LICH_HANG_NGAYDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_LICH_HANG_NGAY entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_LICH_HANG_NGAYDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_LICH_HANG_NGAY entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_LICH_HANG_NGAYDTO))
            {

            }
        }

        //add more

    }
}


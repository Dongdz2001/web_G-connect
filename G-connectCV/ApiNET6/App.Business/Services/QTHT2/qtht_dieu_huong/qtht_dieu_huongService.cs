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
    public class qtht_dieu_huongService : GenericService<dieu_huong>, qtht_dieu_huongIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_dieu_huongService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_dieu_huongProfile>();
                //cfg.CreateMap<IDataRecord, qtht_dieu_huongDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<dieu_huong> QueryBuilder(IQueryable<dieu_huong> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string ma = filter.ma + "";
                if (!string.IsNullOrEmpty(ma))
                {
                    ma = ma.ToLower().Trim();
                    query = query.Where(x => x.ma.ToLower().Contains(ma));
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
                string icon = filter.icon + "";
                if (!string.IsNullOrEmpty(icon))
                {
                    icon = icon.ToLower().Trim();
                    query = query.Where(x => x.icon.ToLower().Contains(icon));
                }
                string so_thu_tu = filter.so_thu_tu + "";
                if (!string.IsNullOrEmpty(so_thu_tu))
                {
                    var int_so_thu_tu = int.Parse(so_thu_tu);
                    query = query.Where(x => x.so_thu_tu == int_so_thu_tu);
                }
                string stt_order = filter.stt_order + "";
                if (!string.IsNullOrEmpty(stt_order))
                {
                    stt_order = stt_order.ToLower().Trim();
                    query = query.Where(x => x.stt_order.ToLower().Contains(stt_order));
                }
                string is_quan_tri = filter.is_quan_tri + "";
                if (!string.IsNullOrEmpty(is_quan_tri))
                {
                    var bool_is_quan_tri = bool.Parse(is_quan_tri);
                    query = query.Where(x => x.is_quan_tri == bool_is_quan_tri);
                }
                string mo_ta = filter.mo_ta + "";
                if (!string.IsNullOrEmpty(mo_ta))
                {
                    mo_ta = mo_ta.ToLower().Trim();
                    query = query.Where(x => x.mo_ta.ToLower().Contains(mo_ta));
                }
                string cap_dieu_huong = filter.cap_dieu_huong + "";
                if (!string.IsNullOrEmpty(cap_dieu_huong))
                {
                    var int_cap_dieu_huong = int.Parse(cap_dieu_huong);
                    query = query.Where(x => x.cap_dieu_huong == int_cap_dieu_huong);
                }
                string muc_luc = filter.muc_luc + "";
                if (!string.IsNullOrEmpty(muc_luc))
                {
                    muc_luc = muc_luc.ToLower().Trim();
                    query = query.Where(x => x.muc_luc.ToLower().Contains(muc_luc));
                }
                string dieu_huong_cap_tren_id = filter.dieu_huong_cap_tren_id + "";
                if (!string.IsNullOrEmpty(dieu_huong_cap_tren_id))
                {
                    var guid_dieu_huong_cap_tren_id = Guid.Parse(dieu_huong_cap_tren_id);
                    query = query.Where(x => x.dieu_huong_cap_tren_id == guid_dieu_huong_cap_tren_id);
                }
                string super_admin = filter.super_admin + "";
                if (!string.IsNullOrEmpty(super_admin))
                {
                    var bool_super_admin = bool.Parse(super_admin);
                    query = query.Where(x => x.super_admin == bool_super_admin);
                }
                string is_router = filter.is_router + "";
                if (!string.IsNullOrEmpty(is_router))
                {
                    var bool_is_router = bool.Parse(is_router);
                    query = query.Where(x => x.is_router == bool_is_router);
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

                    || x.ma.ToLower().Contains(search) 
                    || x.ten.ToLower().Contains(search) 
                    || x.duong_dan.ToLower().Contains(search) 
                    || x.icon.ToLower().Contains(search) 
                    || x.stt_order.ToLower().Contains(search) 
                    || x.mo_ta.ToLower().Contains(search) 
                    || x.muc_luc.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_dieu_huongDTO))
            {
                qtht_dieu_huongDTO qtht_dieu_huongDTO = (qtht_dieu_huongDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_dieu_huongDTO.ma.ToLower() && x.id != qtht_dieu_huongDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref dieu_huong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_dieu_huongDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref dieu_huong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_dieu_huongDTO))
            {

            }
        }

        //add more

    }
}


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
    public class GC_CONG_VIECService : GenericService<GC_CONG_VIEC>, GC_CONG_VIECIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_CONG_VIECService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_CONG_VIECProfile>();
                //cfg.CreateMap<IDataRecord, GC_CONG_VIECDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_CONG_VIEC> QueryBuilder(IQueryable<GC_CONG_VIEC> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string id_chuc_nang = filter.id_chuc_nang + "";
                if (!string.IsNullOrEmpty(id_chuc_nang))
                {
                    var guid_id_chuc_nang = Guid.Parse(id_chuc_nang);
                    query = query.Where(x => x.id_chuc_nang == guid_id_chuc_nang);
                }
                string id_cong_viec_cha = filter.id_cong_viec_cha + "";
                if (!string.IsNullOrEmpty(id_cong_viec_cha))
                {
                    var guid_id_cong_viec_cha = Guid.Parse(id_cong_viec_cha);
                    query = query.Where(x => x.id_cong_viec_cha == guid_id_cong_viec_cha);
                }
                string ma_cong_viec = filter.ma_cong_viec + "";
                if (!string.IsNullOrEmpty(ma_cong_viec))
                {
                    ma_cong_viec = ma_cong_viec.ToLower().Trim();
                    query = query.Where(x => x.ma_cong_viec.ToLower().Contains(ma_cong_viec));
                }
                string ten_cong_viec = filter.ten_cong_viec + "";
                if (!string.IsNullOrEmpty(ten_cong_viec))
                {
                    ten_cong_viec = ten_cong_viec.ToLower().Trim();
                    query = query.Where(x => x.ten_cong_viec.ToLower().Contains(ten_cong_viec));
                }
                string stt = filter.stt + "";
                if (!string.IsNullOrEmpty(stt))
                {
                    var int_stt = int.Parse(stt);
                    query = query.Where(x => x.stt == int_stt);
                }
                string is_cong_viec_nhom = filter.is_cong_viec_nhom + "";
                if (!string.IsNullOrEmpty(is_cong_viec_nhom))
                {
                    var bool_is_cong_viec_nhom = bool.Parse(is_cong_viec_nhom);
                    query = query.Where(x => x.is_cong_viec_nhom == bool_is_cong_viec_nhom);
                }
                string is_da_code = filter.is_da_code + "";
                if (!string.IsNullOrEmpty(is_da_code))
                {
                    var bool_is_da_code = bool.Parse(is_da_code);
                    query = query.Where(x => x.is_da_code == bool_is_da_code);
                }
                string is_da_test = filter.is_da_test + "";
                if (!string.IsNullOrEmpty(is_da_test))
                {
                    var bool_is_da_test = bool.Parse(is_da_test);
                    query = query.Where(x => x.is_da_test == bool_is_da_test);
                }
                string noi_dung = filter.noi_dung + "";
                if (!string.IsNullOrEmpty(noi_dung))
                {
                    noi_dung = noi_dung.ToLower().Trim();
                    query = query.Where(x => x.noi_dung.ToLower().Contains(noi_dung));
                }
                string tham_khao = filter.tham_khao + "";
                if (!string.IsNullOrEmpty(tham_khao))
                {
                    tham_khao = tham_khao.ToLower().Trim();
                    query = query.Where(x => x.tham_khao.ToLower().Contains(tham_khao));
                }
                string so_ngay_estimate = filter.so_ngay_estimate + "";
                if (!string.IsNullOrEmpty(so_ngay_estimate))
                {
                    var int_so_ngay_estimate = int.Parse(so_ngay_estimate);
                    query = query.Where(x => x.so_ngay_estimate == int_so_ngay_estimate);
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
                string id_du_an = filter.id_du_an + "";
                if (!string.IsNullOrEmpty(id_du_an))
                {
                    var guid_id_du_an = Guid.Parse(id_du_an);
                    query = query.Where(x => x.GC_CONG_VIEC_id_chuc_nang.id_du_an == guid_id_du_an);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.ma_cong_viec.ToLower().Contains(search) 
                    || x.ten_cong_viec.ToLower().Contains(search) 
                    || x.noi_dung.ToLower().Contains(search) 
                    || x.tham_khao.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIECDTO))
            {
                GC_CONG_VIECDTO GC_CONG_VIECDTO = (GC_CONG_VIECDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_CONG_VIECDTO.ma.ToLower() && x.id != GC_CONG_VIECDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_CONG_VIECDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIECDTO))
            {

            }
        }

        //add more

    }
}


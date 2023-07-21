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
    public class GC_LICH_TUANService : GenericService<GC_LICH_TUAN>, GC_LICH_TUANIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_LICH_TUANService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_LICH_TUANProfile>();
                //cfg.CreateMap<IDataRecord, GC_LICH_TUANDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_LICH_TUAN> QueryBuilder(IQueryable<GC_LICH_TUAN> query, dynamic filter, string search)
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
                string thu2_sang = filter.thu2_sang + "";
                if (!string.IsNullOrEmpty(thu2_sang))
                {
                    thu2_sang = thu2_sang.ToLower().Trim();
                    query = query.Where(x => x.thu2_sang.ToLower().Contains(thu2_sang));
                }
                string thu2_chieu = filter.thu2_chieu + "";
                if (!string.IsNullOrEmpty(thu2_chieu))
                {
                    thu2_chieu = thu2_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu2_chieu.ToLower().Contains(thu2_chieu));
                }
                string thu3_sang = filter.thu3_sang + "";
                if (!string.IsNullOrEmpty(thu3_sang))
                {
                    thu3_sang = thu3_sang.ToLower().Trim();
                    query = query.Where(x => x.thu3_sang.ToLower().Contains(thu3_sang));
                }
                string thu3_chieu = filter.thu3_chieu + "";
                if (!string.IsNullOrEmpty(thu3_chieu))
                {
                    thu3_chieu = thu3_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu3_chieu.ToLower().Contains(thu3_chieu));
                }
                string thu4_sang = filter.thu4_sang + "";
                if (!string.IsNullOrEmpty(thu4_sang))
                {
                    thu4_sang = thu4_sang.ToLower().Trim();
                    query = query.Where(x => x.thu4_sang.ToLower().Contains(thu4_sang));
                }
                string thu4_chieu = filter.thu4_chieu + "";
                if (!string.IsNullOrEmpty(thu4_chieu))
                {
                    thu4_chieu = thu4_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu4_chieu.ToLower().Contains(thu4_chieu));
                }
                string thu5_sang = filter.thu5_sang + "";
                if (!string.IsNullOrEmpty(thu5_sang))
                {
                    thu5_sang = thu5_sang.ToLower().Trim();
                    query = query.Where(x => x.thu5_sang.ToLower().Contains(thu5_sang));
                }
                string thu5_chieu = filter.thu5_chieu + "";
                if (!string.IsNullOrEmpty(thu5_chieu))
                {
                    thu5_chieu = thu5_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu5_chieu.ToLower().Contains(thu5_chieu));
                }
                string thu6_sang = filter.thu6_sang + "";
                if (!string.IsNullOrEmpty(thu6_sang))
                {
                    thu6_sang = thu6_sang.ToLower().Trim();
                    query = query.Where(x => x.thu6_sang.ToLower().Contains(thu6_sang));
                }
                string thu6_chieu = filter.thu6_chieu + "";
                if (!string.IsNullOrEmpty(thu6_chieu))
                {
                    thu6_chieu = thu6_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu6_chieu.ToLower().Contains(thu6_chieu));
                }
                string thu7_sang = filter.thu7_sang + "";
                if (!string.IsNullOrEmpty(thu7_sang))
                {
                    thu7_sang = thu7_sang.ToLower().Trim();
                    query = query.Where(x => x.thu7_sang.ToLower().Contains(thu7_sang));
                }
                string thu7_chieu = filter.thu7_chieu + "";
                if (!string.IsNullOrEmpty(thu7_chieu))
                {
                    thu7_chieu = thu7_chieu.ToLower().Trim();
                    query = query.Where(x => x.thu7_chieu.ToLower().Contains(thu7_chieu));
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

                    || x.thu2_sang.ToLower().Contains(search) 
                    || x.thu2_chieu.ToLower().Contains(search) 
                    || x.thu3_sang.ToLower().Contains(search) 
                    || x.thu3_chieu.ToLower().Contains(search) 
                    || x.thu4_sang.ToLower().Contains(search) 
                    || x.thu4_chieu.ToLower().Contains(search) 
                    || x.thu5_sang.ToLower().Contains(search) 
                    || x.thu5_chieu.ToLower().Contains(search) 
                    || x.thu6_sang.ToLower().Contains(search) 
                    || x.thu6_chieu.ToLower().Contains(search) 
                    || x.thu7_sang.ToLower().Contains(search) 
                    || x.thu7_chieu.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_LICH_TUANDTO))
            {
                GC_LICH_TUANDTO GC_LICH_TUANDTO = (GC_LICH_TUANDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_LICH_TUANDTO.ma.ToLower() && x.id != GC_LICH_TUANDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_LICH_TUAN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_LICH_TUANDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_LICH_TUAN entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_LICH_TUANDTO))
            {

            }
        }

        //add more

    }
}


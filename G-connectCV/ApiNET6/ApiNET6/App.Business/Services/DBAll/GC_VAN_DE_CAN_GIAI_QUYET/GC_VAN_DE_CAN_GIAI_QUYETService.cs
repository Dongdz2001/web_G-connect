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
    public class GC_VAN_DE_CAN_GIAI_QUYETService : GenericService<GC_VAN_DE_CAN_GIAI_QUYET>, GC_VAN_DE_CAN_GIAI_QUYETIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_VAN_DE_CAN_GIAI_QUYETService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_VAN_DE_CAN_GIAI_QUYETProfile>();
                //cfg.CreateMap<IDataRecord, GC_VAN_DE_CAN_GIAI_QUYETDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_VAN_DE_CAN_GIAI_QUYET> QueryBuilder(IQueryable<GC_VAN_DE_CAN_GIAI_QUYET> query, dynamic filter, string search)
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
                string id_cong_viec = filter.id_cong_viec + "";
                if (!string.IsNullOrEmpty(id_cong_viec))
                {
                    var guid_id_cong_viec = Guid.Parse(id_cong_viec);
                    query = query.Where(x => x.id_cong_viec == guid_id_cong_viec);
                }
                string id_nguoi_gap = filter.id_nguoi_gap + "";
                if (!string.IsNullOrEmpty(id_nguoi_gap))
                {
                    var guid_id_nguoi_gap = Guid.Parse(id_nguoi_gap);
                    query = query.Where(x => x.id_nguoi_gap == guid_id_nguoi_gap);
                }
                string id_nguoi_phoi_hop = filter.id_nguoi_phoi_hop + "";
                if (!string.IsNullOrEmpty(id_nguoi_phoi_hop))
                {
                    var guid_id_nguoi_phoi_hop = Guid.Parse(id_nguoi_phoi_hop);
                    query = query.Where(x => x.id_nguoi_phoi_hop == guid_id_nguoi_phoi_hop);
                }
                string id_nguoi_giai_quyet = filter.id_nguoi_giai_quyet + "";
                if (!string.IsNullOrEmpty(id_nguoi_giai_quyet))
                {
                    var guid_id_nguoi_giai_quyet = Guid.Parse(id_nguoi_giai_quyet);
                    query = query.Where(x => x.id_nguoi_giai_quyet == guid_id_nguoi_giai_quyet);
                }
                string ten_van_de = filter.ten_van_de + "";
                if (!string.IsNullOrEmpty(ten_van_de))
                {
                    ten_van_de = ten_van_de.ToLower().Trim();
                    query = query.Where(x => x.ten_van_de.ToLower().Contains(ten_van_de));
                }
                string noi_dung = filter.noi_dung + "";
                if (!string.IsNullOrEmpty(noi_dung))
                {
                    noi_dung = noi_dung.ToLower().Trim();
                    query = query.Where(x => x.noi_dung.ToLower().Contains(noi_dung));
                }
                string huong_giai_quyet = filter.huong_giai_quyet + "";
                if (!string.IsNullOrEmpty(huong_giai_quyet))
                {
                    huong_giai_quyet = huong_giai_quyet.ToLower().Trim();
                    query = query.Where(x => x.huong_giai_quyet.ToLower().Contains(huong_giai_quyet));
                }
                string da_giai_quyet = filter.da_giai_quyet + "";
                if (!string.IsNullOrEmpty(da_giai_quyet))
                {
                    var bool_da_giai_quyet = bool.Parse(da_giai_quyet);
                    query = query.Where(x => x.da_giai_quyet == bool_da_giai_quyet);
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

                    || x.ten_van_de.ToLower().Contains(search) 
                    || x.noi_dung.ToLower().Contains(search) 
                    || x.huong_giai_quyet.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_VAN_DE_CAN_GIAI_QUYETDTO))
            {
                GC_VAN_DE_CAN_GIAI_QUYETDTO GC_VAN_DE_CAN_GIAI_QUYETDTO = (GC_VAN_DE_CAN_GIAI_QUYETDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_VAN_DE_CAN_GIAI_QUYETDTO.ma.ToLower() && x.id != GC_VAN_DE_CAN_GIAI_QUYETDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_VAN_DE_CAN_GIAI_QUYET entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_VAN_DE_CAN_GIAI_QUYETDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_VAN_DE_CAN_GIAI_QUYET entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_VAN_DE_CAN_GIAI_QUYETDTO))
            {

            }
        }

        //add more

    }
}


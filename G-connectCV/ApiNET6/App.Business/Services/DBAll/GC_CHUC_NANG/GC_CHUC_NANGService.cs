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
    public class GC_CHUC_NANGService : GenericService<GC_CHUC_NANG>, GC_CHUC_NANGIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_CHUC_NANGService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_CHUC_NANGProfile>();
                //cfg.CreateMap<IDataRecord, GC_CHUC_NANGDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_CHUC_NANG> QueryBuilder(IQueryable<GC_CHUC_NANG> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string id_du_an = filter.id_du_an + "";
                if (!string.IsNullOrEmpty(id_du_an))
                {
                    var guid_id_du_an = Guid.Parse(id_du_an);
                    query = query.Where(x => x.id_du_an == guid_id_du_an);
                }
                string id_linh_vuc = filter.id_linh_vuc + "";
                if (!string.IsNullOrEmpty(id_linh_vuc))
                {
                    var guid_id_linh_vuc = Guid.Parse(id_linh_vuc);
                    query = query.Where(x => x.id_linh_vuc == guid_id_linh_vuc);
                }
                string ma_chuc_nang = filter.ma_chuc_nang + "";
                if (!string.IsNullOrEmpty(ma_chuc_nang))
                {
                    ma_chuc_nang = ma_chuc_nang.ToLower().Trim();
                    query = query.Where(x => x.ma_chuc_nang.ToLower().Contains(ma_chuc_nang));
                }
                string ten_chuc_nang = filter.ten_chuc_nang + "";
                if (!string.IsNullOrEmpty(ten_chuc_nang))
                {
                    ten_chuc_nang = ten_chuc_nang.ToLower().Trim();
                    query = query.Where(x => x.ten_chuc_nang.ToLower().Contains(ten_chuc_nang));
                }
                string stt = filter.stt + "";
                if (!string.IsNullOrEmpty(stt))
                {
                    var int_stt = int.Parse(stt);
                    query = query.Where(x => x.stt == int_stt);
                }
                string is_cong_bo = filter.is_cong_bo + "";
                if (!string.IsNullOrEmpty(is_cong_bo))
                {
                    var bool_is_cong_bo = bool.Parse(is_cong_bo);
                    if (bool_is_cong_bo == true)
                        query = query.Where(x => x.is_cong_bo == bool_is_cong_bo);
                    else
                        query = query.Where(x => x.is_cong_bo == null || x.is_cong_bo == bool_is_cong_bo);
                }
                string is_da_code = filter.is_da_code + "";
                if (!string.IsNullOrEmpty(is_da_code))
                {
                    var bool_is_da_code = bool.Parse(is_da_code);
                    if (bool_is_da_code == true)
                        query = query.Where(x => x.is_da_code == bool_is_da_code);
                    else
                        query = query.Where(x => x.is_da_code == null || x.is_da_code == bool_is_da_code);
                }
                string is_da_test = filter.is_da_test + "";
                if (!string.IsNullOrEmpty(is_da_test))
                {
                    var bool_is_da_test = bool.Parse(is_da_test);
                    if (bool_is_da_test == true)
                        query = query.Where(x => x.is_da_test == bool_is_da_test);
                    else
                        query = query.Where(x => x.is_da_test == null || x.is_da_test == bool_is_da_test);
                }
                string noi_dung = filter.noi_dung + "";
                if (!string.IsNullOrEmpty(noi_dung))
                {
                    noi_dung = noi_dung.ToLower().Trim();
                    query = query.Where(x => x.noi_dung.ToLower().Contains(noi_dung));
                }
                string file_dinh_kem = filter.file_dinh_kem + "";
                if (!string.IsNullOrEmpty(file_dinh_kem))
                {
                    file_dinh_kem = file_dinh_kem.ToLower().Trim();
                    query = query.Where(x => x.file_dinh_kem.ToLower().Contains(file_dinh_kem));
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

                    || (x.ma_chuc_nang != null && x.ma_chuc_nang.ToLower().Contains(search))
                    || (x.ten_chuc_nang != null && x.ten_chuc_nang.ToLower().Contains(search))
                    || (x.noi_dung != null && x.noi_dung.ToLower().Contains(search))
                    || (x.file_dinh_kem != null && x.file_dinh_kem.ToLower().Contains(search))
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CHUC_NANGDTO))
            {
                GC_CHUC_NANGDTO GC_CHUC_NANGDTO = (GC_CHUC_NANGDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_CHUC_NANGDTO.ma.ToLower() && x.id != GC_CHUC_NANGDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CHUC_NANG entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_CHUC_NANGDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CHUC_NANG entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CHUC_NANGDTO))
            {

            }
        }

        //add more

    }
}


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
    public class GC_CONG_VIEC_PHAN_CONGService : GenericService<GC_CONG_VIEC_PHAN_CONG>, GC_CONG_VIEC_PHAN_CONGIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_CONG_VIEC_PHAN_CONGService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_CONG_VIEC_PHAN_CONGProfile>();
                //cfg.CreateMap<IDataRecord, GC_CONG_VIEC_PHAN_CONGDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_CONG_VIEC_PHAN_CONG> QueryBuilder(IQueryable<GC_CONG_VIEC_PHAN_CONG> query, dynamic filter, string search)
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
                string id_trang_thai = filter.id_trang_thai + "";
                if (!string.IsNullOrEmpty(id_trang_thai))
                {
                    var guid_id_trang_thai = Guid.Parse(id_trang_thai);
                    query = query.Where(x => x.id_trang_thai == guid_id_trang_thai);
                }
                string id_nguoi_thuc_hien = filter.id_nguoi_thuc_hien + "";
                if (!string.IsNullOrEmpty(id_nguoi_thuc_hien))
                {
                    var guid_id_nguoi_thuc_hien = Guid.Parse(id_nguoi_thuc_hien);
                    query = query.Where(x => x.id_nguoi_thuc_hien == guid_id_nguoi_thuc_hien);
                }
                string id_nguoi_phoi_hop = filter.id_nguoi_phoi_hop + "";
                if (!string.IsNullOrEmpty(id_nguoi_phoi_hop))
                {
                    var guid_id_nguoi_phoi_hop = Guid.Parse(id_nguoi_phoi_hop);
                    query = query.Where(x => x.id_nguoi_phoi_hop == guid_id_nguoi_phoi_hop);
                }
                string id_nguoi_duyet = filter.id_nguoi_duyet + "";
                if (!string.IsNullOrEmpty(id_nguoi_duyet))
                {
                    var guid_id_nguoi_duyet = Guid.Parse(id_nguoi_duyet);
                    query = query.Where(x => x.id_nguoi_duyet == guid_id_nguoi_duyet);
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
                string is_da_nop_bai = filter.is_da_nop_bai + "";
                if (!string.IsNullOrEmpty(is_da_nop_bai))
                {
                    var bool_is_da_nop_bai = bool.Parse(is_da_nop_bai);
                    query = query.Where(x => x.is_da_nop_bai == bool_is_da_nop_bai);
                }
                string is_da_duyet = filter.is_da_duyet + "";
                if (!string.IsNullOrEmpty(is_da_duyet))
                {
                    var bool_is_da_duyet = bool.Parse(is_da_duyet);
                    query = query.Where(x => x.is_da_duyet == bool_is_da_duyet);
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
                string dac_ta = filter.dac_ta + "";
                if (!string.IsNullOrEmpty(dac_ta))
                {
                    dac_ta = dac_ta.ToLower().Trim();
                    query = query.Where(x => x.dac_ta.ToLower().Contains(dac_ta));
                }
                string tra_loi = filter.tra_loi + "";
                if (!string.IsNullOrEmpty(tra_loi))
                {
                    tra_loi = tra_loi.ToLower().Trim();
                    query = query.Where(x => x.tra_loi.ToLower().Contains(tra_loi));
                }
                string log_review = filter.log_review + "";
                if (!string.IsNullOrEmpty(log_review))
                {
                    log_review = log_review.ToLower().Trim();
                    query = query.Where(x => x.log_review.ToLower().Contains(log_review));
                }
                string file_ket_qua = filter.file_ket_qua + "";
                if (!string.IsNullOrEmpty(file_ket_qua))
                {
                    file_ket_qua = file_ket_qua.ToLower().Trim();
                    query = query.Where(x => x.file_ket_qua.ToLower().Contains(file_ket_qua));
                }
                string so_ngay_estimate = filter.so_ngay_estimate + "";
                if (!string.IsNullOrEmpty(so_ngay_estimate))
                {
                    var int_so_ngay_estimate = int.Parse(so_ngay_estimate);
                    query = query.Where(x => x.so_ngay_estimate == int_so_ngay_estimate);
                }
                string so_ngay_thuc_hien = filter.so_ngay_thuc_hien + "";
                if (!string.IsNullOrEmpty(so_ngay_thuc_hien))
                {
                    var int_so_ngay_thuc_hien = int.Parse(so_ngay_thuc_hien);
                    query = query.Where(x => x.so_ngay_thuc_hien == int_so_ngay_thuc_hien);
                }
                string ngay_ket_thuc_du_kien = filter.ngay_ket_thuc_du_kien + "";
                if (!string.IsNullOrEmpty(ngay_ket_thuc_du_kien))
                {
                    var date_ngay_ket_thuc_du_kien = DateTime.Parse(ngay_ket_thuc_du_kien);
                    query = query.Where(x => x.ngay_ket_thuc_du_kien == date_ngay_ket_thuc_du_kien);
                }
                string bd_ngay_ket_thuc_du_kien = filter.bd_ngay_ket_thuc_du_kien + "";
                if (!string.IsNullOrEmpty(bd_ngay_ket_thuc_du_kien))
                {
                    var bd_date_ngay_ket_thuc_du_kien = DateTime.Parse(bd_ngay_ket_thuc_du_kien);
                    query = query.Where(x => x.ngay_ket_thuc_du_kien >= bd_date_ngay_ket_thuc_du_kien);
                }
                string kt_ngay_ket_thuc_du_kien = filter.kt_ngay_ket_thuc_du_kien + "";
                if (!string.IsNullOrEmpty(kt_ngay_ket_thuc_du_kien))
                {
                    var kt_date_ngay_ket_thuc_du_kien = DateTime.Parse(kt_ngay_ket_thuc_du_kien);
                    query = query.Where(x => x.ngay_ket_thuc_du_kien <= kt_date_ngay_ket_thuc_du_kien);
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
                string diem_so = filter.diem_so + "";
                if (!string.IsNullOrEmpty(diem_so))
                {
                    var int_diem_so = int.Parse(diem_so);
                    query = query.Where(x => x.diem_so == int_diem_so);
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
                    query = query.Where(x => x.GC_CHUC_NANG_id_chuc_nang.id_du_an == guid_id_du_an);
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
                    || x.dac_ta.ToLower().Contains(search) 
                    || x.tra_loi.ToLower().Contains(search) 
                    || x.log_review.ToLower().Contains(search) 
                    || x.file_ket_qua.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIEC_PHAN_CONGDTO))
            {
                GC_CONG_VIEC_PHAN_CONGDTO GC_CONG_VIEC_PHAN_CONGDTO = (GC_CONG_VIEC_PHAN_CONGDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_CONG_VIEC_PHAN_CONGDTO.ma.ToLower() && x.id != GC_CONG_VIEC_PHAN_CONGDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC_PHAN_CONG entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_CONG_VIEC_PHAN_CONGDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC_PHAN_CONG entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIEC_PHAN_CONGDTO))
            {

            }
        }

        //add more

    }
}


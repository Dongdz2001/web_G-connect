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
    public class qtht_nguoi_dungService : GenericService<nguoi_dung>, qtht_nguoi_dungIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_nguoi_dungService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_nguoi_dungProfile>();
                //cfg.CreateMap<IDataRecord, qtht_nguoi_dungDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<nguoi_dung> QueryBuilder(IQueryable<nguoi_dung> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string tai_khoan = filter.tai_khoan + "";
                if (!string.IsNullOrEmpty(tai_khoan))
                {
                    tai_khoan = tai_khoan.ToLower().Trim();
                    query = query.Where(x => x.tai_khoan.ToLower().Contains(tai_khoan));
                }
                string mat_khau = filter.mat_khau + "";
                if (!string.IsNullOrEmpty(mat_khau))
                {
                    mat_khau = mat_khau.ToLower().Trim();
                    query = query.Where(x => x.mat_khau.ToLower().Contains(mat_khau));
                }
                string salt_code = filter.salt_code + "";
                if (!string.IsNullOrEmpty(salt_code))
                {
                    salt_code = salt_code.ToLower().Trim();
                    query = query.Where(x => x.salt_code.ToLower().Contains(salt_code));
                }
                string ten = filter.ten + "";
                if (!string.IsNullOrEmpty(ten))
                {
                    ten = ten.ToLower().Trim();
                    query = query.Where(x => x.ten.ToLower().Contains(ten));
                }
                string trang_thai = filter.trang_thai + "";
                if (!string.IsNullOrEmpty(trang_thai))
                {
                    var int_trang_thai = int.Parse(trang_thai);
                    query = query.Where(x => x.trang_thai == int_trang_thai);
                }
                string super_admin = filter.super_admin + "";
                if (!string.IsNullOrEmpty(super_admin))
                {
                    var bool_super_admin = bool.Parse(super_admin);
                    query = query.Where(x => x.super_admin == bool_super_admin);
                }
                string email = filter.email + "";
                if (!string.IsNullOrEmpty(email))
                {
                    email = email.ToLower().Trim();
                    query = query.Where(x => x.email.ToLower().Contains(email));
                }
                string so_dien_thoai = filter.so_dien_thoai + "";
                if (!string.IsNullOrEmpty(so_dien_thoai))
                {
                    so_dien_thoai = so_dien_thoai.ToLower().Trim();
                    query = query.Where(x => x.so_dien_thoai.ToLower().Contains(so_dien_thoai));
                }
                string anh_dai_dien_url = filter.anh_dai_dien_url + "";
                if (!string.IsNullOrEmpty(anh_dai_dien_url))
                {
                    anh_dai_dien_url = anh_dai_dien_url.ToLower().Trim();
                    query = query.Where(x => x.anh_dai_dien_url.ToLower().Contains(anh_dai_dien_url));
                }
                string is_dau_moi = filter.is_dau_moi + "";
                if (!string.IsNullOrEmpty(is_dau_moi))
                {
                    var bool_is_dau_moi = bool.Parse(is_dau_moi);
                    query = query.Where(x => x.is_dau_moi == bool_is_dau_moi);
                }
                string chuc_vu_id = filter.chuc_vu_id + "";
                if (!string.IsNullOrEmpty(chuc_vu_id))
                {
                    var guid_chuc_vu_id = Guid.Parse(chuc_vu_id);
                    query = query.Where(x => x.chuc_vu_id == guid_chuc_vu_id);
                }
                string file_dinh_kem_id = filter.file_dinh_kem_id + "";
                if (!string.IsNullOrEmpty(file_dinh_kem_id))
                {
                    var guid_file_dinh_kem_id = Guid.Parse(file_dinh_kem_id);
                    query = query.Where(x => x.file_dinh_kem_id == guid_file_dinh_kem_id);
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

                    || x.tai_khoan.ToLower().Contains(search) 
                    || x.mat_khau.ToLower().Contains(search) 
                    || x.salt_code.ToLower().Contains(search) 
                    || x.ten.ToLower().Contains(search) 
                    || x.email.ToLower().Contains(search) 
                    || x.so_dien_thoai.ToLower().Contains(search) 
                    || x.anh_dai_dien_url.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nguoi_dungDTO))
            {
                qtht_nguoi_dungDTO qtht_nguoi_dungDTO = (qtht_nguoi_dungDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_nguoi_dungDTO.ma.ToLower() && x.id != qtht_nguoi_dungDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_nguoi_dungDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nguoi_dungDTO))
            {

            }
        }

        //add more

    }
}


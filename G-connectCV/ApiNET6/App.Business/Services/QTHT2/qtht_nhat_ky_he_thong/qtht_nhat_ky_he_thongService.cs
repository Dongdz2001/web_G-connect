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
    public class qtht_nhat_ky_he_thongService : GenericService<nhat_ky_he_thong>, qtht_nhat_ky_he_thongIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_nhat_ky_he_thongService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_nhat_ky_he_thongProfile>();
                //cfg.CreateMap<IDataRecord, qtht_nhat_ky_he_thongDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<nhat_ky_he_thong> QueryBuilder(IQueryable<nhat_ky_he_thong> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string id = filter.id + "";
                if (!string.IsNullOrEmpty(id))
                {
                    var guid_id = Guid.Parse(id);
                    query = query.Where(x => x.id == guid_id);
                }
                string bang = filter.bang + "";
                if (!string.IsNullOrEmpty(bang))
                {
                    bang = bang.ToLower().Trim();
                    query = query.Where(x => x.bang.ToLower().Contains(bang));
                }
                string ban_ghi_id = filter.ban_ghi_id + "";
                if (!string.IsNullOrEmpty(ban_ghi_id))
                {
                    var guid_ban_ghi_id = Guid.Parse(ban_ghi_id);
                    query = query.Where(x => x.ban_ghi_id == guid_ban_ghi_id);
                }
                string nguoi_thuc_hien_id = filter.nguoi_thuc_hien_id + "";
                if (!string.IsNullOrEmpty(nguoi_thuc_hien_id))
                {
                    var guid_nguoi_thuc_hien_id = Guid.Parse(nguoi_thuc_hien_id);
                    query = query.Where(x => x.nguoi_thuc_hien_id == guid_nguoi_thuc_hien_id);
                }
                string hanh_dong = filter.hanh_dong + "";
                if (!string.IsNullOrEmpty(hanh_dong))
                {
                    hanh_dong = hanh_dong.ToLower().Trim();
                    query = query.Where(x => x.hanh_dong.ToLower().Contains(hanh_dong));
                }
                string noi_dung = filter.noi_dung + "";
                if (!string.IsNullOrEmpty(noi_dung))
                {
                    noi_dung = noi_dung.ToLower().Trim();
                    query = query.Where(x => x.noi_dung.ToLower().Contains(noi_dung));
                }
                string duong_dan = filter.duong_dan + "";
                if (!string.IsNullOrEmpty(duong_dan))
                {
                    duong_dan = duong_dan.ToLower().Trim();
                    query = query.Where(x => x.duong_dan.ToLower().Contains(duong_dan));
                }
                string is_deleted = filter.is_deleted + "";
                if (!string.IsNullOrEmpty(is_deleted))
                {
                    var bool_is_deleted = bool.Parse(is_deleted);
                    query = query.Where(x => x.is_deleted == bool_is_deleted);
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

                    || x.bang.ToLower().Contains(search) 
                    || x.hanh_dong.ToLower().Contains(search) 
                    || x.noi_dung.ToLower().Contains(search) 
                    || x.duong_dan.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nhat_ky_he_thongDTO))
            {
                qtht_nhat_ky_he_thongDTO qtht_nhat_ky_he_thongDTO = (qtht_nhat_ky_he_thongDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_nhat_ky_he_thongDTO.ma.ToLower() && x.id != qtht_nhat_ky_he_thongDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhat_ky_he_thong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_nhat_ky_he_thongDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhat_ky_he_thong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nhat_ky_he_thongDTO))
            {

            }
        }

        //add more

    }
}


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
    public class GC_CONG_VIEC_CHECKLISTService : GenericService<GC_CONG_VIEC_CHECKLIST>, GC_CONG_VIEC_CHECKLISTIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public GC_CONG_VIEC_CHECKLISTService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GC_CONG_VIEC_CHECKLISTProfile>();
                //cfg.CreateMap<IDataRecord, GC_CONG_VIEC_CHECKLISTDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<GC_CONG_VIEC_CHECKLIST> QueryBuilder(IQueryable<GC_CONG_VIEC_CHECKLIST> query, dynamic filter, string search)
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
                string id_loai_checklist = filter.id_loai_checklist + "";
                if (!string.IsNullOrEmpty(id_loai_checklist))
                {
                    var guid_id_loai_checklist = Guid.Parse(id_loai_checklist);
                    query = query.Where(x => x.id_loai_checklist == guid_id_loai_checklist);
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
                string ket_qua_mong_muon = filter.ket_qua_mong_muon + "";
                if (!string.IsNullOrEmpty(ket_qua_mong_muon))
                {
                    ket_qua_mong_muon = ket_qua_mong_muon.ToLower().Trim();
                    query = query.Where(x => x.ket_qua_mong_muon.ToLower().Contains(ket_qua_mong_muon));
                }
                string ghi_chu_khac = filter.ghi_chu_khac + "";
                if (!string.IsNullOrEmpty(ghi_chu_khac))
                {
                    ghi_chu_khac = ghi_chu_khac.ToLower().Trim();
                    query = query.Where(x => x.ghi_chu_khac.ToLower().Contains(ghi_chu_khac));
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
                    || x.ket_qua_mong_muon.ToLower().Contains(search) 
                    || x.ghi_chu_khac.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIEC_CHECKLISTDTO))
            {
                GC_CONG_VIEC_CHECKLISTDTO GC_CONG_VIEC_CHECKLISTDTO = (GC_CONG_VIEC_CHECKLISTDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == GC_CONG_VIEC_CHECKLISTDTO.ma.ToLower() && x.id != GC_CONG_VIEC_CHECKLISTDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC_CHECKLIST entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(GC_CONG_VIEC_CHECKLISTDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref GC_CONG_VIEC_CHECKLIST entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(GC_CONG_VIEC_CHECKLISTDTO))
            {

            }
        }

        //add more

    }
}


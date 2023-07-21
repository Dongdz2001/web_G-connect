using App.Business.Base;
using App.Business.Utils;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Business.Services.QTHT
{
    public class NhatKyHeThongService : GenericService<nhat_ky_he_thong>, INhatKyHeThongService
    {
        public NhatKyHeThongService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<NhatKyHeThongProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
        }

        protected override IQueryable<nhat_ky_he_thong> QueryBuilder(IQueryable<nhat_ky_he_thong> query, dynamic filter, string search)
        {
            var current = AppHelpers.GetCurrentUser();
         

            if (filter != null)
            {
                String nguoi_dung_id = filter.nguoi_dung_id;
                if (!string.IsNullOrEmpty(nguoi_dung_id))
                {
                    var nguoi_dung_id_guid = new Guid(nguoi_dung_id);
                    query = query.Where(x => x.nguoi_thuc_hien_id == nguoi_dung_id_guid);
                }
            }

            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => x.nguoi_dung.ten.ToLower().Contains(search) 
                                        || x.noi_dung.ToLower().Contains(search)
                                    );
            }

            query = query.Where(x => x.is_deleted != true);

            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            if (typeof(TDto) == typeof(NhatKyHeThongDTO))
            {

            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhat_ky_he_thong entity)
        {
            if (typeof(TDto) != typeof(NhatKyHeThongDTO))
            {
                return;
            }

        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhat_ky_he_thong entity)
        {
            if (typeof(TDto) == typeof(NhatKyHeThongDTO))
            {

            }
        }

        public async Task<bool> CreateNhatKyHeThong(NhatKyHeThongDTO objNhatKy)
        {
            try
            {
                var repo_nhat_ky_he_thong_loai = _dbContext.Set<nhat_ky_he_thong_loai>();
                var ten_hanh_dong = repo_nhat_ky_he_thong_loai.Where(x => x.hanh_dong == objNhatKy.hanh_dong).Select(y => y.ten_hanh_dong).FirstOrDefault();


                var currentUser = AppHelpers.GetCurrentUser();
                var nktemp = new nhat_ky_he_thong();

                nktemp.bang = objNhatKy.bang;
                nktemp.nguoi_thuc_hien_id = currentUser.id;
                nktemp.ban_ghi_id = objNhatKy.ban_ghi_id;
                nktemp.duong_dan = objNhatKy.duong_dan;
                nktemp.hanh_dong = objNhatKy.hanh_dong;
                if(!string.IsNullOrEmpty(objNhatKy.noi_dung))
                {
                    nktemp.noi_dung = objNhatKy.noi_dung;
                }    
                else
                {
                    nktemp.noi_dung = currentUser.ten + " " + (ten_hanh_dong ?? "");
                }

                nktemp.is_deleted = false;

                nktemp.ngay_tao = DateTime.Now;
                nktemp.nguoi_tao_id = currentUser.id;
                nktemp.ngay_chinh_sua = DateTime.Now;
                nktemp.nguoi_chinh_sua_id = currentUser.id;

                _dbContext.nhat_ky_he_thong.Add(nktemp);

                if (_dbContext.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNhatKyHeThong(Guid id)
        {
            try
            {
                // del ngan sach
                var obj = _repo.Find(id);
                if(obj != null)
                {
                    obj.is_deleted = true;
                }
                if (_dbContext.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

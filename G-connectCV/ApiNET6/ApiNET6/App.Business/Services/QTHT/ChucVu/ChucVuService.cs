using App.Business.Base;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Linq;

namespace App.Business.Services.QTHT
{
    public class ChucVuService : GenericService<chuc_vu>, IChucVuService
    {
        public ChucVuService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<ChucVuProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
        }

        protected override IQueryable<chuc_vu> QueryBuilder(IQueryable<chuc_vu> query, dynamic filter, string search)
        {
            if (filter != null)
            {
                String ten = filter.ten;
                if (!string.IsNullOrEmpty(ten))
                {
                    ten = ten.ToLower().Trim();
                    query = query.Where(x => x.ten.ToLower().Contains(ten));
                }
                String mo_ta = filter.mo_ta;
                if (!string.IsNullOrEmpty(mo_ta))
                {
                    mo_ta = mo_ta.ToLower().Trim();
                    query = query.Where(x => x.mo_ta.ToLower().Contains(mo_ta));
                }
            }

            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => x.ten.ToLower().Contains(search) ||
                                         x.mo_ta.ToLower().Contains(search));
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            if (typeof(TDto) == typeof(ChucVuDTO))
            {
                ChucVuDTO chucVuDTO = (ChucVuDTO)(object)dto;
                //xu ly tai day
                var checkExist = _repo.Where(x => x.ma.ToLower() == chucVuDTO.ma.ToLower() && x.id != chucVuDTO.id);
                if (checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã chức vụ đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref chuc_vu entity)
        {
            if (typeof(TDto) != typeof(ChucVuDTO))
            {
                return;
            }

        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref chuc_vu entity)
        {
            if (typeof(TDto) == typeof(ChucVuDTO))
            {

            }
        }


    }
}

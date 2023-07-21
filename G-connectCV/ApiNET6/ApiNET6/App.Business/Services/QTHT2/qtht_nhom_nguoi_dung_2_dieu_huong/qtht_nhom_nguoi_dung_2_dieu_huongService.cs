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
    public class qtht_nhom_nguoi_dung_2_dieu_huongService : GenericService<nhom_nguoi_dung_2_dieu_huong>, qtht_nhom_nguoi_dung_2_dieu_huongIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_nhom_nguoi_dung_2_dieu_huongService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_nhom_nguoi_dung_2_dieu_huongProfile>();
                //cfg.CreateMap<IDataRecord, qtht_nhom_nguoi_dung_2_dieu_huongDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<nhom_nguoi_dung_2_dieu_huong> QueryBuilder(IQueryable<nhom_nguoi_dung_2_dieu_huong> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string nhom_nguoi_dung_id = filter.nhom_nguoi_dung_id + "";
                if (!string.IsNullOrEmpty(nhom_nguoi_dung_id))
                {
                    var guid_nhom_nguoi_dung_id = Guid.Parse(nhom_nguoi_dung_id);
                    query = query.Where(x => x.nhom_nguoi_dung_id == guid_nhom_nguoi_dung_id);
                }
                string dieu_huong_id = filter.dieu_huong_id + "";
                if (!string.IsNullOrEmpty(dieu_huong_id))
                {
                    var guid_dieu_huong_id = Guid.Parse(dieu_huong_id);
                    query = query.Where(x => x.dieu_huong_id == guid_dieu_huong_id);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nhom_nguoi_dung_2_dieu_huongDTO))
            {
                qtht_nhom_nguoi_dung_2_dieu_huongDTO qtht_nhom_nguoi_dung_2_dieu_huongDTO = (qtht_nhom_nguoi_dung_2_dieu_huongDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_nhom_nguoi_dung_2_dieu_huongDTO.ma.ToLower() && x.id != qtht_nhom_nguoi_dung_2_dieu_huongDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhom_nguoi_dung_2_dieu_huong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_nhom_nguoi_dung_2_dieu_huongDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhom_nguoi_dung_2_dieu_huong entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nhom_nguoi_dung_2_dieu_huongDTO))
            {

            }
        }

        //add more

    }
}


using App.Business.Base;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Business.Services.QTHT
{
    public class CauHinhMaService : GenericService<cau_hinh_ma>, ICauHinhMaService
    {
        public CauHinhMaService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<CauHinhMaProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();

        }

        protected override IQueryable<cau_hinh_ma> QueryBuilder(IQueryable<cau_hinh_ma> query, dynamic filter, string search)
        {
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {

        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref cau_hinh_ma entity)
        {
            if (typeof(TDto) != typeof(CauHinhMaDTO))
            {
                return;
            }
            CauHinhMaDTO cauHinhMaDTO = (CauHinhMaDTO)(object)dto;
        }
        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref cau_hinh_ma entity)
        {
            if (typeof(TDto) == typeof(CauHinhMaDTO))
            {
                CauHinhMaDTO cauHinhMaDTO = (CauHinhMaDTO)(object)dto;
            }
        }

        public string GetCHMa(string ma)
        {
            try
            {
                return ma != null ? (_repo.Where(x => x.ma == ma).FirstOrDefault() != null ? _repo.Where(x => x.ma == ma).FirstOrDefault().gia_tri : "") : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

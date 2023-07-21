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
    public class GoogleConfigService : GenericService<google_config>, IGoogleConfigService
    {
        public GoogleConfigService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<GoogleConfigProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
        }

        protected override IQueryable<google_config> QueryBuilder(IQueryable<google_config> query, dynamic filter, string search)
        {
            if (filter != null)
            {
                
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
               
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            if (typeof(TDto) == typeof(GoogleConfigDTO))
            {
                
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref google_config entity)
        {
            if (typeof(TDto) != typeof(GoogleConfigDTO))
            {
                return;
            }
            GoogleConfigDTO donviDTO = (GoogleConfigDTO)(object)dto;
           
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref google_config entity)
        {
            if (typeof(TDto) == typeof(GoogleConfigDTO))
            {
                GoogleConfigDTO donviDto = (GoogleConfigDTO)(object)dto;
                
                if (isNew == true)
                {
                   
                }
            }
        }

       
    }
}

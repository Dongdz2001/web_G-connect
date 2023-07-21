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
    public class ApiResourcePropertiesService : GenericServiceInt<ApiResourceProperties>, ApiResourcePropertiesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ApiResourcePropertiesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ApiResourcePropertiesProfile>();
                //cfg.CreateMap<IDataRecord, ApiResourcePropertiesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ApiResourceProperties> QueryBuilder(IQueryable<ApiResourceProperties> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Key = filter.Key + "";
                if (!string.IsNullOrEmpty(Key))
                {
                    Key = Key.ToLower().Trim();
                    query = query.Where(x => x.Key.ToLower().Contains(Key));
                }
                string Value = filter.Value + "";
                if (!string.IsNullOrEmpty(Value))
                {
                    Value = Value.ToLower().Trim();
                    query = query.Where(x => x.Value.ToLower().Contains(Value));
                }
                string ApiResourceId = filter.ApiResourceId + "";
                if (!string.IsNullOrEmpty(ApiResourceId))
                {
                    var int_ApiResourceId = int.Parse(ApiResourceId);
                    query = query.Where(x => x.ApiResourceId == int_ApiResourceId);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.Key.ToLower().Contains(search) 
                    || x.Value.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourcePropertiesDTO))
            {
                ApiResourcePropertiesDTO ApiResourcePropertiesDTO = (ApiResourcePropertiesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ApiResourcePropertiesDTO.ma.ToLower() && x.id != ApiResourcePropertiesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResourceProperties entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ApiResourcePropertiesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResourceProperties entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourcePropertiesDTO))
            {

            }
        }

        //add more

    }
}


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
    public class ApiResourceScopesService : GenericServiceInt<ApiResourceScopes>, ApiResourceScopesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ApiResourceScopesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ApiResourceScopesProfile>();
                //cfg.CreateMap<IDataRecord, ApiResourceScopesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ApiResourceScopes> QueryBuilder(IQueryable<ApiResourceScopes> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Scope = filter.Scope + "";
                if (!string.IsNullOrEmpty(Scope))
                {
                    Scope = Scope.ToLower().Trim();
                    query = query.Where(x => x.Scope.ToLower().Contains(Scope));
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

                    || x.Scope.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourceScopesDTO))
            {
                ApiResourceScopesDTO ApiResourceScopesDTO = (ApiResourceScopesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ApiResourceScopesDTO.ma.ToLower() && x.id != ApiResourceScopesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResourceScopes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ApiResourceScopesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResourceScopes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourceScopesDTO))
            {

            }
        }

        //add more

    }
}


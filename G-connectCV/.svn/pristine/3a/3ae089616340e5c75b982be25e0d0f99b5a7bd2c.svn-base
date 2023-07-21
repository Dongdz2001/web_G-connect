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
    public class ApiScopesService : GenericServiceInt<ApiScopes>, ApiScopesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ApiScopesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ApiScopesProfile>();
                //cfg.CreateMap<IDataRecord, ApiScopesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ApiScopes> QueryBuilder(IQueryable<ApiScopes> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Enabled = filter.Enabled + "";
                if (!string.IsNullOrEmpty(Enabled))
                {
                    var bool_Enabled = bool.Parse(Enabled);
                    query = query.Where(x => x.Enabled == bool_Enabled);
                }
                string Name = filter.Name + "";
                if (!string.IsNullOrEmpty(Name))
                {
                    Name = Name.ToLower().Trim();
                    query = query.Where(x => x.Name.ToLower().Contains(Name));
                }
                string DisplayName = filter.DisplayName + "";
                if (!string.IsNullOrEmpty(DisplayName))
                {
                    DisplayName = DisplayName.ToLower().Trim();
                    query = query.Where(x => x.DisplayName.ToLower().Contains(DisplayName));
                }
                string Description = filter.Description + "";
                if (!string.IsNullOrEmpty(Description))
                {
                    Description = Description.ToLower().Trim();
                    query = query.Where(x => x.Description.ToLower().Contains(Description));
                }
                string Required = filter.Required + "";
                if (!string.IsNullOrEmpty(Required))
                {
                    var bool_Required = bool.Parse(Required);
                    query = query.Where(x => x.Required == bool_Required);
                }
                string Emphasize = filter.Emphasize + "";
                if (!string.IsNullOrEmpty(Emphasize))
                {
                    var bool_Emphasize = bool.Parse(Emphasize);
                    query = query.Where(x => x.Emphasize == bool_Emphasize);
                }
                string ShowInDiscoveryDocument = filter.ShowInDiscoveryDocument + "";
                if (!string.IsNullOrEmpty(ShowInDiscoveryDocument))
                {
                    var bool_ShowInDiscoveryDocument = bool.Parse(ShowInDiscoveryDocument);
                    query = query.Where(x => x.ShowInDiscoveryDocument == bool_ShowInDiscoveryDocument);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.Name.ToLower().Contains(search) 
                    || x.DisplayName.ToLower().Contains(search) 
                    || x.Description.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiScopesDTO))
            {
                ApiScopesDTO ApiScopesDTO = (ApiScopesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ApiScopesDTO.ma.ToLower() && x.id != ApiScopesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiScopes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ApiScopesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiScopes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiScopesDTO))
            {

            }
        }

        //add more

    }
}


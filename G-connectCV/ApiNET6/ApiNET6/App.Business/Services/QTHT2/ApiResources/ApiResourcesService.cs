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
    public class ApiResourcesService : GenericServiceInt<ApiResources>, ApiResourcesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ApiResourcesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ApiResourcesProfile>();
                //cfg.CreateMap<IDataRecord, ApiResourcesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ApiResources> QueryBuilder(IQueryable<ApiResources> query, dynamic filter, string search)
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
                string AllowedAccessTokenSigningAlgorithms = filter.AllowedAccessTokenSigningAlgorithms + "";
                if (!string.IsNullOrEmpty(AllowedAccessTokenSigningAlgorithms))
                {
                    AllowedAccessTokenSigningAlgorithms = AllowedAccessTokenSigningAlgorithms.ToLower().Trim();
                    query = query.Where(x => x.AllowedAccessTokenSigningAlgorithms.ToLower().Contains(AllowedAccessTokenSigningAlgorithms));
                }
                string ShowInDiscoveryDocument = filter.ShowInDiscoveryDocument + "";
                if (!string.IsNullOrEmpty(ShowInDiscoveryDocument))
                {
                    var bool_ShowInDiscoveryDocument = bool.Parse(ShowInDiscoveryDocument);
                    query = query.Where(x => x.ShowInDiscoveryDocument == bool_ShowInDiscoveryDocument);
                }
                string Created = filter.Created + "";
                if (!string.IsNullOrEmpty(Created))
                {
                    var date_Created = DateTime.Parse(Created);
                    query = query.Where(x => x.Created == date_Created);
                }
                string bd_Created = filter.bd_Created + "";
                if (!string.IsNullOrEmpty(bd_Created))
                {
                    var bd_date_Created = DateTime.Parse(bd_Created);
                    query = query.Where(x => x.Created >= bd_date_Created);
                }
                string kt_Created = filter.kt_Created + "";
                if (!string.IsNullOrEmpty(kt_Created))
                {
                    var kt_date_Created = DateTime.Parse(kt_Created);
                    query = query.Where(x => x.Created <= kt_date_Created);
                }
                string Updated = filter.Updated + "";
                if (!string.IsNullOrEmpty(Updated))
                {
                    var date_Updated = DateTime.Parse(Updated);
                    query = query.Where(x => x.Updated == date_Updated);
                }
                string bd_Updated = filter.bd_Updated + "";
                if (!string.IsNullOrEmpty(bd_Updated))
                {
                    var bd_date_Updated = DateTime.Parse(bd_Updated);
                    query = query.Where(x => x.Updated >= bd_date_Updated);
                }
                string kt_Updated = filter.kt_Updated + "";
                if (!string.IsNullOrEmpty(kt_Updated))
                {
                    var kt_date_Updated = DateTime.Parse(kt_Updated);
                    query = query.Where(x => x.Updated <= kt_date_Updated);
                }
                string LastAccessed = filter.LastAccessed + "";
                if (!string.IsNullOrEmpty(LastAccessed))
                {
                    var date_LastAccessed = DateTime.Parse(LastAccessed);
                    query = query.Where(x => x.LastAccessed == date_LastAccessed);
                }
                string bd_LastAccessed = filter.bd_LastAccessed + "";
                if (!string.IsNullOrEmpty(bd_LastAccessed))
                {
                    var bd_date_LastAccessed = DateTime.Parse(bd_LastAccessed);
                    query = query.Where(x => x.LastAccessed >= bd_date_LastAccessed);
                }
                string kt_LastAccessed = filter.kt_LastAccessed + "";
                if (!string.IsNullOrEmpty(kt_LastAccessed))
                {
                    var kt_date_LastAccessed = DateTime.Parse(kt_LastAccessed);
                    query = query.Where(x => x.LastAccessed <= kt_date_LastAccessed);
                }
                string NonEditable = filter.NonEditable + "";
                if (!string.IsNullOrEmpty(NonEditable))
                {
                    var bool_NonEditable = bool.Parse(NonEditable);
                    query = query.Where(x => x.NonEditable == bool_NonEditable);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.Name.ToLower().Contains(search) 
                    || x.DisplayName.ToLower().Contains(search) 
                    || x.Description.ToLower().Contains(search) 
                    || x.AllowedAccessTokenSigningAlgorithms.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourcesDTO))
            {
                ApiResourcesDTO ApiResourcesDTO = (ApiResourcesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ApiResourcesDTO.ma.ToLower() && x.id != ApiResourcesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResources entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ApiResourcesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ApiResources entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ApiResourcesDTO))
            {

            }
        }

        //add more

    }
}


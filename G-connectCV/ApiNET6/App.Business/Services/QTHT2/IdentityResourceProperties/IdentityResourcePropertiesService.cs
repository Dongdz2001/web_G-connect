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
    public class IdentityResourcePropertiesService : GenericServiceInt<IdentityResourceProperties>, IdentityResourcePropertiesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public IdentityResourcePropertiesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<IdentityResourcePropertiesProfile>();
                //cfg.CreateMap<IDataRecord, IdentityResourcePropertiesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<IdentityResourceProperties> QueryBuilder(IQueryable<IdentityResourceProperties> query, dynamic filter, string search)
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
                string IdentityResourceId = filter.IdentityResourceId + "";
                if (!string.IsNullOrEmpty(IdentityResourceId))
                {
                    var int_IdentityResourceId = int.Parse(IdentityResourceId);
                    query = query.Where(x => x.IdentityResourceId == int_IdentityResourceId);
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
            if (typeof(TDto) == typeof(IdentityResourcePropertiesDTO))
            {
                IdentityResourcePropertiesDTO IdentityResourcePropertiesDTO = (IdentityResourcePropertiesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == IdentityResourcePropertiesDTO.ma.ToLower() && x.id != IdentityResourcePropertiesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref IdentityResourceProperties entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(IdentityResourcePropertiesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref IdentityResourceProperties entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(IdentityResourcePropertiesDTO))
            {

            }
        }

        //add more

    }
}


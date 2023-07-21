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
    public class ClientClaimsService : GenericServiceInt<ClientClaims>, ClientClaimsIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ClientClaimsService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ClientClaimsProfile>();
                //cfg.CreateMap<IDataRecord, ClientClaimsDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ClientClaims> QueryBuilder(IQueryable<ClientClaims> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Type = filter.Type + "";
                if (!string.IsNullOrEmpty(Type))
                {
                    Type = Type.ToLower().Trim();
                    query = query.Where(x => x.Type.ToLower().Contains(Type));
                }
                string Value = filter.Value + "";
                if (!string.IsNullOrEmpty(Value))
                {
                    Value = Value.ToLower().Trim();
                    query = query.Where(x => x.Value.ToLower().Contains(Value));
                }
                string ClientId = filter.ClientId + "";
                if (!string.IsNullOrEmpty(ClientId))
                {
                    var int_ClientId = int.Parse(ClientId);
                    query = query.Where(x => x.ClientId == int_ClientId);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.Type.ToLower().Contains(search) 
                    || x.Value.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientClaimsDTO))
            {
                ClientClaimsDTO ClientClaimsDTO = (ClientClaimsDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ClientClaimsDTO.ma.ToLower() && x.id != ClientClaimsDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ClientClaims entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ClientClaimsDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ClientClaims entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientClaimsDTO))
            {

            }
        }

        //add more

    }
}


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
    public class ClientSecretsService : GenericServiceInt<ClientSecrets>, ClientSecretsIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public ClientSecretsService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<ClientSecretsProfile>();
                //cfg.CreateMap<IDataRecord, ClientSecretsDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<ClientSecrets> QueryBuilder(IQueryable<ClientSecrets> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Id = filter.Id + "";
                if (!string.IsNullOrEmpty(Id))
                {
                    var int_Id = int.Parse(Id);
                    query = query.Where(x => x.id == int_Id);
                }
                string Description = filter.Description + "";
                if (!string.IsNullOrEmpty(Description))
                {
                    Description = Description.ToLower().Trim();
                    query = query.Where(x => x.Description.ToLower().Contains(Description));
                }
                string Value = filter.Value + "";
                if (!string.IsNullOrEmpty(Value))
                {
                    Value = Value.ToLower().Trim();
                    query = query.Where(x => x.Value.ToLower().Contains(Value));
                }
                string Expiration = filter.Expiration + "";
                if (!string.IsNullOrEmpty(Expiration))
                {
                    var date_Expiration = DateTime.Parse(Expiration);
                    query = query.Where(x => x.Expiration == date_Expiration);
                }
                string bd_Expiration = filter.bd_Expiration + "";
                if (!string.IsNullOrEmpty(bd_Expiration))
                {
                    var bd_date_Expiration = DateTime.Parse(bd_Expiration);
                    query = query.Where(x => x.Expiration >= bd_date_Expiration);
                }
                string kt_Expiration = filter.kt_Expiration + "";
                if (!string.IsNullOrEmpty(kt_Expiration))
                {
                    var kt_date_Expiration = DateTime.Parse(kt_Expiration);
                    query = query.Where(x => x.Expiration <= kt_date_Expiration);
                }
                string Type = filter.Type + "";
                if (!string.IsNullOrEmpty(Type))
                {
                    Type = Type.ToLower().Trim();
                    query = query.Where(x => x.Type.ToLower().Contains(Type));
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

                    || x.Description.ToLower().Contains(search) 
                    || x.Value.ToLower().Contains(search) 
                    || x.Type.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientSecretsDTO))
            {
                ClientSecretsDTO ClientSecretsDTO = (ClientSecretsDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == ClientSecretsDTO.ma.ToLower() && x.id != ClientSecretsDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ClientSecrets entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(ClientSecretsDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref ClientSecrets entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(ClientSecretsDTO))
            {

            }
        }

        //add more

    }
}


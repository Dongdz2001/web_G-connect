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
    public class PersistedGrantsService : GenericServiceInt<PersistedGrants>, PersistedGrantsIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public PersistedGrantsService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<PersistedGrantsProfile>();
                //cfg.CreateMap<IDataRecord, PersistedGrantsDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<PersistedGrants> QueryBuilder(IQueryable<PersistedGrants> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string Key = filter.Key + "";
                if (!string.IsNullOrEmpty(Key))
                {
                    Key = Key.ToLower().Trim();
                    query = query.Where(x => x.Key.ToLower().Contains(Key));
                }
                string Type = filter.Type + "";
                if (!string.IsNullOrEmpty(Type))
                {
                    Type = Type.ToLower().Trim();
                    query = query.Where(x => x.Type.ToLower().Contains(Type));
                }
                string SubjectId = filter.SubjectId + "";
                if (!string.IsNullOrEmpty(SubjectId))
                {
                    SubjectId = SubjectId.ToLower().Trim();
                    query = query.Where(x => x.SubjectId.ToLower().Contains(SubjectId));
                }
                string SessionId = filter.SessionId + "";
                if (!string.IsNullOrEmpty(SessionId))
                {
                    SessionId = SessionId.ToLower().Trim();
                    query = query.Where(x => x.SessionId.ToLower().Contains(SessionId));
                }
                string ClientId = filter.ClientId + "";
                if (!string.IsNullOrEmpty(ClientId))
                {
                    ClientId = ClientId.ToLower().Trim();
                    query = query.Where(x => x.ClientId.ToLower().Contains(ClientId));
                }
                string Description = filter.Description + "";
                if (!string.IsNullOrEmpty(Description))
                {
                    Description = Description.ToLower().Trim();
                    query = query.Where(x => x.Description.ToLower().Contains(Description));
                }
                string CreationTime = filter.CreationTime + "";
                if (!string.IsNullOrEmpty(CreationTime))
                {
                    var date_CreationTime = DateTime.Parse(CreationTime);
                    query = query.Where(x => x.CreationTime == date_CreationTime);
                }
                string bd_CreationTime = filter.bd_CreationTime + "";
                if (!string.IsNullOrEmpty(bd_CreationTime))
                {
                    var bd_date_CreationTime = DateTime.Parse(bd_CreationTime);
                    query = query.Where(x => x.CreationTime >= bd_date_CreationTime);
                }
                string kt_CreationTime = filter.kt_CreationTime + "";
                if (!string.IsNullOrEmpty(kt_CreationTime))
                {
                    var kt_date_CreationTime = DateTime.Parse(kt_CreationTime);
                    query = query.Where(x => x.CreationTime <= kt_date_CreationTime);
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
                string ConsumedTime = filter.ConsumedTime + "";
                if (!string.IsNullOrEmpty(ConsumedTime))
                {
                    var date_ConsumedTime = DateTime.Parse(ConsumedTime);
                    query = query.Where(x => x.ConsumedTime == date_ConsumedTime);
                }
                string bd_ConsumedTime = filter.bd_ConsumedTime + "";
                if (!string.IsNullOrEmpty(bd_ConsumedTime))
                {
                    var bd_date_ConsumedTime = DateTime.Parse(bd_ConsumedTime);
                    query = query.Where(x => x.ConsumedTime >= bd_date_ConsumedTime);
                }
                string kt_ConsumedTime = filter.kt_ConsumedTime + "";
                if (!string.IsNullOrEmpty(kt_ConsumedTime))
                {
                    var kt_date_ConsumedTime = DateTime.Parse(kt_ConsumedTime);
                    query = query.Where(x => x.ConsumedTime <= kt_date_ConsumedTime);
                }
                string Data = filter.Data + "";
                if (!string.IsNullOrEmpty(Data))
                {
                    Data = Data.ToLower().Trim();
                    query = query.Where(x => x.Data.ToLower().Contains(Data));
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                    || x.Key.ToLower().Contains(search) 
                    || x.Type.ToLower().Contains(search) 
                    || x.SubjectId.ToLower().Contains(search) 
                    || x.SessionId.ToLower().Contains(search) 
                    || x.ClientId.ToLower().Contains(search) 
                    || x.Description.ToLower().Contains(search) 
                    || x.Data.ToLower().Contains(search) 
                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(PersistedGrantsDTO))
            {
                PersistedGrantsDTO PersistedGrantsDTO = (PersistedGrantsDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == PersistedGrantsDTO.ma.ToLower() && x.id != PersistedGrantsDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref PersistedGrants entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(PersistedGrantsDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref PersistedGrants entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(PersistedGrantsDTO))
            {

            }
        }

        //add more

    }
}


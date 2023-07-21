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
    public class DeviceCodesService : GenericServiceInt<DeviceCodes>, DeviceCodesIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public DeviceCodesService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfileInt>();
                cfg.AddProfile<DeviceCodesProfile>();
                //cfg.CreateMap<IDataRecord, DeviceCodesDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<DeviceCodes> QueryBuilder(IQueryable<DeviceCodes> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string UserCode = filter.UserCode + "";
                if (!string.IsNullOrEmpty(UserCode))
                {
                    UserCode = UserCode.ToLower().Trim();
                    query = query.Where(x => x.UserCode.ToLower().Contains(UserCode));
                }
                string DeviceCode = filter.DeviceCode + "";
                if (!string.IsNullOrEmpty(DeviceCode))
                {
                    DeviceCode = DeviceCode.ToLower().Trim();
                    query = query.Where(x => x.DeviceCode.ToLower().Contains(DeviceCode));
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

                    || x.UserCode.ToLower().Contains(search) 
                    || x.DeviceCode.ToLower().Contains(search) 
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
            if (typeof(TDto) == typeof(DeviceCodesDTO))
            {
                DeviceCodesDTO DeviceCodesDTO = (DeviceCodesDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == DeviceCodesDTO.ma.ToLower() && x.id != DeviceCodesDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref DeviceCodes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(DeviceCodesDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref DeviceCodes entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(DeviceCodesDTO))
            {

            }
        }

        //add more

    }
}


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
    public class qtht_nguoi_dung_2_nhom_nguoi_dungService : GenericService<nguoi_dung_2_nhom_nguoi_dung>, qtht_nguoi_dung_2_nhom_nguoi_dungIService
    {
        //private readonly IFileDinhKemService _fileSV;
        public qtht_nguoi_dung_2_nhom_nguoi_dungService(APPContext dbContext)
           : base(dbContext)
        {
            //Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                //cfg.AddDataReaderMapping();
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<qtht_nguoi_dung_2_nhom_nguoi_dungProfile>();
                //cfg.CreateMap<IDataRecord, qtht_nguoi_dung_2_nhom_nguoi_dungDTO>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();
            //_dbContext.Database.SetCommandTimeout(0);
            //_fileSV = new FileDinhKemService(dbContext);
        }

        protected override IQueryable<nguoi_dung_2_nhom_nguoi_dung> QueryBuilder(IQueryable<nguoi_dung_2_nhom_nguoi_dung> query, dynamic filter, string search)
        {
            if (filter != null)
            {

                string nguoi_dung_id = filter.nguoi_dung_id + "";
                if (!string.IsNullOrEmpty(nguoi_dung_id))
                {
                    var guid_nguoi_dung_id = Guid.Parse(nguoi_dung_id);
                    query = query.Where(x => x.nguoi_dung_id == guid_nguoi_dung_id);
                }
                string nhom_nguoi_dung_id = filter.nhom_nguoi_dung_id + "";
                if (!string.IsNullOrEmpty(nhom_nguoi_dung_id))
                {
                    var guid_nhom_nguoi_dung_id = Guid.Parse(nhom_nguoi_dung_id);
                    query = query.Where(x => x.nhom_nguoi_dung_id == guid_nhom_nguoi_dung_id);
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => false

                );
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nguoi_dung_2_nhom_nguoi_dungDTO))
            {
                qtht_nguoi_dung_2_nhom_nguoi_dungDTO qtht_nguoi_dung_2_nhom_nguoi_dungDTO = (qtht_nguoi_dung_2_nhom_nguoi_dungDTO)(object)dto;
                //xu ly tai day
                //var checkExist = _repo.Where(x => x.ma.ToLower() == qtht_nguoi_dung_2_nhom_nguoi_dungDTO.ma.ToLower() && x.id != qtht_nguoi_dung_2_nhom_nguoi_dungDTO.id);
                if (false) //checkExist.Count() > 0)
                {
                    ErrorCtr.DataExits("Mã đã tồn tại, vui lòng nhập mã khác.");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung_2_nhom_nguoi_dung entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) != typeof(qtht_nguoi_dung_2_nhom_nguoi_dungDTO))
            {
                return;
            }
        }

        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nguoi_dung_2_nhom_nguoi_dung entity)
        {
            var currentUser = AppHelpers.GetCurrentUser();
            if (typeof(TDto) == typeof(qtht_nguoi_dung_2_nhom_nguoi_dungDTO))
            {

            }
        }

        //add more

    }
}


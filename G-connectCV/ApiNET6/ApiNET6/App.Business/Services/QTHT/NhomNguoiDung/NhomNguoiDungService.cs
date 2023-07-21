using App.Business.Base;
using App.Common.Base;
using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Business.Services.QTHT
{
    public class NhomNguoiDungService : GenericService<nhom_nguoi_dung>, INhomNguoiDungService
    {
        public NhomNguoiDungService(APPContext dbContext)
           : base(dbContext)
        {
            ///Khởi tạo mapperconfiuration
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BaseProfile>();
                cfg.AddProfile<NhomNguoiDungProfile>();
            });
            _mapper = _mapperCfg.CreateMapper();
            _mapperCfg.AssertConfigurationIsValid();

        }

        protected override IQueryable<nhom_nguoi_dung> QueryBuilder(IQueryable<nhom_nguoi_dung> query, dynamic filter, string search)
        {
            if (filter != null)
            {
                String ma = filter.ma;
                if (!string.IsNullOrEmpty(ma))
                {
                    ma = ma.ToLower().Trim();
                    query = query.Where(x => x.ma.ToLower().Contains(ma));
                }
                String ten = filter.ten;
                if (!string.IsNullOrEmpty(ten))
                {
                    ten = ten.ToLower().Trim();
                    query = query.Where(x => x.ten.ToLower().Contains(ten));
                }
                String mota = filter.mota;
                if (!string.IsNullOrEmpty(mota))
                {
                    mota = mota.ToLower().Trim();
                    query = query.Where(x => x.mota.ToLower().Contains(mota));
                }
            }
            if (search != null && search != "")
            {
                search = search.ToLower().Trim();
                query = query.Where(x => x.ma.ToLower().Contains(search) ||
                                         x.ten.ToLower().Contains(search) ||
                                         x.mota.ToLower().Contains(search));
            }
            return query;
        }
        protected override void BeforeMapper<TDto>(bool isNew, ref TDto dto)
        {
            if (typeof(TDto) == typeof(NhomNguoiDungDTO))
            {
                NhomNguoiDungDTO nhomnguoidungDTO = (NhomNguoiDungDTO)(object)dto;
                var isExits = _repo.Where(x => x.ma.ToLower() == nhomnguoidungDTO.ma.ToLower() && x.id != nhomnguoidungDTO.id);
                if (isExits.Count()  > 0)
                {
                    ErrorCtr.DataExits("Mã nhóm đã tồn tại, vui lòng kiểm tra lại thông tin");
                }
            }
        }
        protected override void BeforeAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhom_nguoi_dung entity)
        {
            if (typeof(TDto) != typeof(NhomNguoiDungDTO))
            {
                return;
            }
            NhomNguoiDungDTO nguoidungDTO = (NhomNguoiDungDTO)(object)dto;
            if (isNew)
            {

            }
        }
        protected override void AfterAddOrUpdate<TDto>(bool isNew, ref TDto dto, ref nhom_nguoi_dung entity)
        {
            if (typeof(TDto) != typeof(NhomNguoiDungDTO))
            {
                return;
            }
            NhomNguoiDungDTO nhomnguoidungDTO = (NhomNguoiDungDTO)(object)dto;
            if (isNew)
            {
                #region add người dùng vào bảng trung gian
                if (nhomnguoidungDTO.ds_nguoidung != null)
                {
                    foreach (var item in nhomnguoidungDTO.ds_nguoidung)
                    {
                        var infoNguoiDung = _dbContext.nguoi_dung.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoNguoiDung != null)
                        {
                            nguoi_dung_2_nhom_nguoi_dung nguoi_dung_2_nhom_nguoi_dung = new nguoi_dung_2_nhom_nguoi_dung();
                            nguoi_dung_2_nhom_nguoi_dung.nguoi_dung_id = infoNguoiDung.id;
                            nguoi_dung_2_nhom_nguoi_dung.nhom_nguoi_dung_id = entity.id;
                            entity.ds_nguoi_dung.Add(nguoi_dung_2_nhom_nguoi_dung);
                        }
                    }
                }
                #endregion

                #region add điều hướng vào bảng trung gian
                if (nhomnguoidungDTO.ds_dieuhuong != null)
                {
                    foreach (var item in nhomnguoidungDTO.ds_dieuhuong)
                    {
                        var infoDieuHuong = _dbContext.dieu_huong.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoDieuHuong != null)
                        {
                            nhom_nguoi_dung_2_dieu_huong nhom_nguoi_dung_2_dieu_huong = new nhom_nguoi_dung_2_dieu_huong();
                            nhom_nguoi_dung_2_dieu_huong.nhom_nguoi_dung_id = entity.id;
                            nhom_nguoi_dung_2_dieu_huong.dieu_huong_id = infoDieuHuong.id;
                            entity.ds_dieu_huong.Add(nhom_nguoi_dung_2_dieu_huong);
                        }
                    }
                }
                #endregion
            }
            else
            {
                var nguoiDung = _dbContext.nhom_nguoi_dung.Find(entity.id);
                nguoiDung.ds_dieu_huong.Clear();

                #region add điều hướng vào bảng trung gian
                if (nhomnguoidungDTO.ds_dieuhuong != null)
                {
                    foreach (var item in nhomnguoidungDTO.ds_dieuhuong)
                    {
                        var infoDieuHuong = _dbContext.dieu_huong.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoDieuHuong != null)
                        {
                            nhom_nguoi_dung_2_dieu_huong nhom_nguoi_dung_2_dieu_huong = new nhom_nguoi_dung_2_dieu_huong();
                            nhom_nguoi_dung_2_dieu_huong.nhom_nguoi_dung_id = entity.id;
                            nhom_nguoi_dung_2_dieu_huong.dieu_huong_id = infoDieuHuong.id;
                            entity.ds_dieu_huong.Add(nhom_nguoi_dung_2_dieu_huong);
                        }
                    }
                }
                #endregion
            }
        }
        public bool AddUserToGroup(UpdateNguoiDungFromNhomND obj)
        {
            try
            {
                var nhomNguoiDung = _dbContext.nhom_nguoi_dung.Find(obj.nhom_id);
                nhomNguoiDung.ds_nguoi_dung.Clear();
                if (obj != null)
                {
                    foreach (var item in obj.lts_nguoi_dung_id)
                    {
                        var infoNguoiDung = _dbContext.nguoi_dung.Where(x => x.id == item.id).FirstOrDefault();
                        if (infoNguoiDung != null)
                        {
                            nguoi_dung_2_nhom_nguoi_dung nguoi_dung_2_nhom_nguoi_dung = new nguoi_dung_2_nhom_nguoi_dung();
                            nguoi_dung_2_nhom_nguoi_dung.nhom_nguoi_dung_id = obj.nhom_id;
                            nguoi_dung_2_nhom_nguoi_dung.nguoi_dung_id = infoNguoiDung.id;
                            nhomNguoiDung.ds_nguoi_dung.Add(nguoi_dung_2_nhom_nguoi_dung);
                            _dbContext.nhom_nguoi_dung.Update(nhomNguoiDung);
                        }
                    }
                    if (_dbContext.SaveChanges() >= 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectSimpleDTO> danhSachNguoiDungQLTC()
        {
            try
            {
                var res = new List<SelectSimpleDTO>();
                var CBQLTC = _dbContext.cau_hinh_ma.Where(x => x.ma == "CBQLTC").FirstOrDefault();
                if(CBQLTC != null)
                {
                    var nhomNguoiDung = _repo.Where(x => x.ma == CBQLTC.gia_tri).FirstOrDefault();
                    if (nhomNguoiDung != null && nhomNguoiDung.ds_nguoi_dung.Any())
                    {
                        res = nhomNguoiDung.ds_nguoi_dung.Select(x => new SelectSimpleDTO
                        {
                            value = x.nguoi_dung_id,
                            label = x.nguoi_dung.ten
                        }).ToList();
                    }
                }    
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

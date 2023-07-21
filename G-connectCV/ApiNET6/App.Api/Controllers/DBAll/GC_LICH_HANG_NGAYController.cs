﻿using App.Business.Services.DBAll;
using App.Business.Services.QTHT;
using App.Business.Utils;
using App.Common.Base;
using Microsoft.AspNetCore.Mvc;
using NetOffice.ExcelApi;
using NetOffice.WordApi;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace App.Api.Controllers.DBAll
{
    /// <summary>
    /// GC_LICH_HANG_NGAY
    /// </summary>
    [Route("api/link-GC_LICH_HANG_NGAY")]

    //phongnhxxx [AuthorizeApi]
    [ApiController]
    public class GC_LICH_HANG_NGAYController : ControllerBase
    {
        private readonly GC_LICH_HANG_NGAYIService _serviceGC_LICH_HANG_NGAY;
        private readonly INhatKyHeThongService _nhatkyhethongservice;
        public GC_LICH_HANG_NGAYController(GC_LICH_HANG_NGAYIService serviceGC_LICH_HANG_NGAY,
            INhatKyHeThongService nhatkyhethongservice)
        {
            _serviceGC_LICH_HANG_NGAY = serviceGC_LICH_HANG_NGAY;
            _nhatkyhethongservice = nhatkyhethongservice;
        }

        #region GetPage
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get(int page = 1, int page_size = 0, string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.GetManyAsync<GC_LICH_HANG_NGAYDTO>(page, page_size, sort, filter, search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region GetAll 
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAll(string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.GetManyAsync<GC_LICH_HANG_NGAYDTO>(1, 1000000, sort, filter, search);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Get2Select
        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <param name="page">default = 1, lựa chọn page hiển thị</param>
        /// <param name="page_size"> cấu hình số dòng trả ra trong 1 page </param>
        /// <param name="sort">  sort = { field:value }</param>
        /// <param name="filter"> filter = { field:value }</param>
        /// <param name="search">Từ khóa tìm kiếm </param>
        /// <returns></returns>
        [HttpGet]
        [Route("select")]
        public async Task<ActionResult> GetSelect(string sort = null, string filter = null, string search = null)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.GetManyAsync<GC_LICH_HANG_NGAYSelectDTO>(1, 1000000, sort, filter, search);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region GetbyId
        /// <summary>
        /// Lấy thông tin 1 bản ghi
        /// </summary>
        /// <param name="id">là id của bản ghi</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.GetByIdAsync<GC_LICH_HANG_NGAYDTO>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Create
        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu thêm mới</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] GC_LICH_HANG_NGAYDTO obj)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.CreateAsync<GC_LICH_HANG_NGAYDTO>(obj);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "GC_LICH_HANG_NGAY";
                        nkht.ban_ghi_id = (result.id);
                        nkht.duong_dan = "/link-GC_LICH_HANG_NGAY-view/" + result.id.ToString();
                        nkht.hanh_dong = "208";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// Cập nhật 
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu cập nhật</param>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<ActionResult> Update([FromBody] GC_LICH_HANG_NGAYDTO obj, Guid id)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.UpdateAsync<GC_LICH_HANG_NGAYDTO>(obj, id);

                try
                {
                    if (result != null)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "GC_LICH_HANG_NGAY";
                        nkht.ban_ghi_id = (result.id);
                        nkht.duong_dan = "/link-GC_LICH_HANG_NGAY-view/" + result.id.ToString();
                        nkht.hanh_dong = "234";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Xóa 1
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.DeleteAsync(id);

                try
                {
                    if (result > 0)
                    {
                        NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                        nkht.bang = "GC_LICH_HANG_NGAY";
                        nkht.ban_ghi_id = (id);
                        nkht.duong_dan = "";
                        nkht.hanh_dong = "235";

                        _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                    }
                }
                catch (Exception ex)
                {
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }

        }
        #endregion

        #region Deletes
        /// <summary>
        /// Xóa nhiều 
        /// </summary>
        /// <param name="ids"> VD: ids=id1,id2,id3</param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletes")]
        public async Task<ActionResult> Deletes([FromBody] List<Guid> ids)
        {

            try
            {
                var result = await _serviceGC_LICH_HANG_NGAY.DeletesAsync(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion


        [HttpGet]
        [Route("checkIn")]
        public async Task<ActionResult> CheckIn()
        {
            try
            {
                var currentUser = AppHelpers.GetCurrentUser();
                var obj = (await _serviceGC_LICH_HANG_NGAY.GetManyAsync<GC_LICH_HANG_NGAYDTO>(1, 1000, null, "{\"id_nguoi_thuc_hien\":\"" + currentUser.id + "\", \"ngay_lam_viec\":\"" + DateTime.Now.Date + "\"}", null)).data.FirstOrDefault();
                if (obj == null)
                {
                    obj = new GC_LICH_HANG_NGAYDTO { id_nguoi_thuc_hien = currentUser.id, ngay_checkin = DateTime.Now, ngay_lam_viec = DateTime.Now.Date };
                    obj = await _serviceGC_LICH_HANG_NGAY.CreateAsync<GC_LICH_HANG_NGAYDTO>(obj);
                }
                if (obj != null)
                {
                    if (obj.ngay_checkin == null) obj.ngay_checkin = DateTime.Now;
                    var result = await _serviceGC_LICH_HANG_NGAY.UpdateAsync<GC_LICH_HANG_NGAYDTO>(obj, obj.id);

                    try
                    {
                        if (result != null)
                        {
                            NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                            nkht.bang = "GC_LICH_HANG_NGAY";
                            nkht.ban_ghi_id = (result.id);
                            nkht.duong_dan = "/link-GC_LICH_HANG_NGAY-view/" + result.id.ToString();
                            nkht.hanh_dong = "234";

                            _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return Ok(result);
                }
                else
                    return Ok(null);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }

        [HttpGet]
        [Route("checkOut")]
        public async Task<ActionResult> CheckOut()
        {
            try
            {
                var currentUser = AppHelpers.GetCurrentUser();
                var obj = (await _serviceGC_LICH_HANG_NGAY.GetManyAsync<GC_LICH_HANG_NGAYDTO>(1, 1000, null, "{\"id_nguoi_thuc_hien\":\"" + currentUser.id + "\", \"ngay_lam_viec\":\"" + DateTime.Now.Date + "\"}", null)).data.FirstOrDefault();
                if (obj == null)
                {
                    obj = new GC_LICH_HANG_NGAYDTO { id_nguoi_thuc_hien = currentUser.id, ngay_checkin = DateTime.Now, ngay_lam_viec = DateTime.Now.Date };
                    obj = await _serviceGC_LICH_HANG_NGAY.CreateAsync<GC_LICH_HANG_NGAYDTO>(obj);
                }
                if (obj != null)
                {
                    if (obj.ngay_checkout == null) obj.ngay_checkout = DateTime.Now;
                    var result = await _serviceGC_LICH_HANG_NGAY.UpdateAsync<GC_LICH_HANG_NGAYDTO>(obj, obj.id);

                    try
                    {
                        if (result != null)
                        {
                            NhatKyHeThongDTO nkht = new NhatKyHeThongDTO();
                            nkht.bang = "GC_LICH_HANG_NGAY";
                            nkht.ban_ghi_id = (result.id);
                            nkht.duong_dan = "/link-GC_LICH_HANG_NGAY-view/" + result.id.ToString();
                            nkht.hanh_dong = "234";

                            _nhatkyhethongservice.CreateNhatKyHeThong(nkht);
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return Ok(result);
                }
                else
                    return Ok(null);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        //add more actions

    }
}

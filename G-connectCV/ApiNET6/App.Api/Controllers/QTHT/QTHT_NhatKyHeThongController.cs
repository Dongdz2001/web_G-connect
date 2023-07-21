﻿using App.Business.Services.QTHT;
using App.Common.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Controllers.QTHT
{
    /// <summary>
    /// QTHT - đơn vị
    /// </summary>
    [Route("api/qtht-nhat-ky-he-thong")]
    //phongnhxxx [AuthorizeApi]
    [ApiController]
    public class QTHT_NhatKyHeThongController : ControllerBase
    {
        private readonly INhatKyHeThongService _service;
        public QTHT_NhatKyHeThongController(INhatKyHeThongService service)
        {
            _service = service;
        }

        #region GetAll 
        /// <summary>
        /// Lấy danh sách chức năng
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
                var result = await _service.GetManyAsync<NhatKyHeThongDTO>(page, page_size, sort, filter, search);
                return Ok(result);
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
        /// Lấy thông tin 1 chức năng
        /// </summary>
        /// <param name="id">là id của bản ghi</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync<NhatKyHeThongDTO>(id);
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
        /// Thêm mới chức năng
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu thêm mới</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NhatKyHeThongDTO obj)
        {
            try
            {
                var result = await _service.CreateAsync<NhatKyHeThongDTO>(obj);
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
        /// Cập nhật chức năng
        /// </summary>
        /// <param name="obj">object dạng json chứa dữ liệu cập nhật</param>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<ActionResult> Update([FromBody] NhatKyHeThongDTO obj, Guid id)
        {
            try
            {
                var result = await _service.UpdateAsync<NhatKyHeThongDTO>(obj, id);
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
        /// Xóa 1 chức năng
        /// </summary>
        /// <param name="id">id của bản ghi</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                //var result = await _service.DeleteAsync(id);
                var result = _service.DeleteNhatKyHeThong(id);
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
        /// Xóa nhiều chức năng
        /// </summary>
        /// <param name="ids"> VD: ids=id1,id2,id3</param>
        /// <returns></returns>
        [HttpPost]
        [Route("deletes")]
        public async Task<ActionResult> Deletes([FromBody] List<Guid> ids)
        {

            try
            {
                var result = await _service.DeletesAsync(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var err = ErrorCtr.ExtractErrorInfo(ex);
                return StatusCode(Convert.ToInt32(err.statusCode), err);
            }
        }
        #endregion

       
       
    }
}